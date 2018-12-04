//******************************************************************************************************
//  ExpressionTree.h - Gbtc
//
//  Copyright � 2018, Grid Protection Alliance.  All Rights Reserved.
//
//  Licensed to the Grid Protection Alliance (GPA) under one or more contributor license agreements. See
//  the NOTICE file distributed with this work for additional information regarding copyright ownership.
//  The GPA licenses this file to you under the MIT License (MIT), the "License"; you may not use this
//  file except in compliance with the License. You may obtain a copy of the License at:
//
//      http://opensource.org/licenses/MIT
//
//  Unless agreed to in writing, the subject software distributed under the License is distributed on an
//  "AS-IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. Refer to the
//  License for the specific language governing permissions and limitations.
//
//  Code Modification History:
//  ----------------------------------------------------------------------------------------------------
//  12/02/2018 - J. Ritchie Carroll
//       Generated original version of source code.
//
//******************************************************************************************************

#ifndef __EXPRESSION_TREE_H
#define __EXPRESSION_TREE_H

#include "../../Common/CommonTypes.h"
#include "../../DataSet/DataSet.h"

namespace GSF {
namespace TimeSeries {
namespace Transport
{

// Simple exception type thrown by the expression tree
class ExpressionTreeException : public Exception
{
private:
    std::string m_message;

public:
    ExpressionTreeException(std::string message) noexcept;
    const char* what() const noexcept;
};

enum class ExpressionType
{
    Value,
    Unary,
    Column,
    Operator,
    Function
};

// These data types are reduced to a more reasonable set of possible
// literal types that can be represented in a filter expression, as a
// result all data table column values will be mapped to these types.
// The behavior has been targeted to match that of parsed literal
// expressions in .NET DataSet operations. See:
// https://docs.microsoft.com/en-us/dotnet/api/system.data.datacolumn.expression?redirectedfrom=MSDN&view=netframework-4.7.2#parsing-literal-expressions
enum class ExpressionDataType
{
    Boolean,    // bool
    Int32,      // int32_t
    Int64,      // int64_t
    Decimal,    // decimal_t
    Double,     // float64_t
    String,     // string
    Guid,       // Guid
    DateTime,   // time_t
    Null        // nullptr
};

const char* ExpressionDataTypeAcronym[];
const char* EnumName(ExpressionDataType type);

bool IsIntegerType(ExpressionDataType type);
bool IsNumericType(ExpressionDataType type);

// Base class for all expression types
class Expression;
typedef SharedPtr<Expression> ExpressionPtr;

class Expression
{
public:
    Expression(ExpressionType type, ExpressionDataType dataType, bool isNullable = false);

    const ExpressionType Type;
    const ExpressionDataType DataType;
    const bool IsNullable;
};

class ValueExpression : public Expression
{
private:
    void ValidateDataType(ExpressionDataType targetType) const;

public:
    ValueExpression(ExpressionDataType dataType, const GSF::TimeSeries::Object& value, bool isNullable = false);

    const GSF::TimeSeries::Object& Value;

    bool IsNull() const;
    std::string ToString() const;

    // The following functions are data type validated
    Nullable<bool> ValueAsBoolean() const;
    Nullable<int32_t> ValueAsInt32() const;
    Nullable<int64_t> ValueAsInt64() const;
    Nullable<decimal_t> ValueAsDecimal() const;
    Nullable<float64_t> ValueAsDouble() const;
    Nullable<std::string> ValueAsString() const;
    Nullable<Guid> ValueAsGuid() const;
    Nullable<time_t> ValueAsDateTime() const;
};

typedef SharedPtr<ValueExpression> ValueExpressionPtr;

enum class ExpressionUnaryType
{
    Plus,
    Minus,
    Not
};

class UnaryExpression : public Expression
{
public:
    UnaryExpression(ExpressionUnaryType unaryType, const ExpressionPtr& value);

    const ExpressionUnaryType UnaryType;
    const ExpressionPtr& Value;
};

typedef SharedPtr<UnaryExpression> UnaryExpressionPtr;

class ColumnExpression : public Expression
{
public:
    ColumnExpression(const GSF::DataSet::DataColumnPtr& column);

    const GSF::DataSet::DataColumnPtr& Column;
};

typedef SharedPtr<ColumnExpression> ColumnExpressionPtr;

enum class ExpressionOperatorType
{
    Multiply,
    Divide,
    Modulus,
    Add,
    Subtract,
    BitShiftLeft,
    BitShiftRight,
    BitwiseAnd,
    BitwiseOr,
    LessThan,
    LessThanOrEqual,
    GreaterThan,
    GreaterThanOrEqual,
    Equal,
    NotEqual,
    IsNull,
    IsNotNull,
    And,
    Or
};

class OperatorExpression : public Expression
{
public:
    OperatorExpression(ExpressionDataType dataType, ExpressionOperatorType operatorType);

    const ExpressionOperatorType OperatorType;
    ExpressionPtr Left;
    ExpressionPtr Right;
};

typedef SharedPtr<OperatorExpression> OperatorExpressionPtr;

enum class ExpressionFunctionType
{
    Coalesce,
    Convert,
    ImmediateIf,
    Len,
    RegExp,
    SubString,
    Trim
};

class FunctionExpression : public Expression
{
public:
    FunctionExpression(ExpressionDataType dataType, ExpressionFunctionType functionType, const std::vector<ExpressionPtr>& arguments);

    const ExpressionFunctionType FunctionType;
    const std::vector<ExpressionPtr>& Arguments;
};

typedef SharedPtr<FunctionExpression> FunctionExpressionPtr;

class ExpressionTree
{
private:
    DataSet::DataRowPtr m_currentRow;

    ExpressionPtr Evaluate(const ExpressionPtr&  node);
    ExpressionPtr EvaluateUnary(const ExpressionPtr& node);
    ExpressionPtr EvaluateColumn(const ExpressionPtr& node) const;
    ExpressionPtr EvaluateFunction(const ExpressionPtr& node);
    ExpressionPtr EvaluateOperator(const ExpressionPtr& node);
public:
    ExpressionTree(std::string measurementTableName, const DataSet::DataTablePtr& measurements);

    const std::string MeasurementTableName;
    const DataSet::DataTablePtr& Measurements;
    ExpressionPtr Root = nullptr;

    bool Evaluate(const DataSet::DataRowPtr& row);

    static const ValueExpressionPtr True;
    static const ValueExpressionPtr False;
    static const ValueExpressionPtr Null;
};

typedef SharedPtr<ExpressionTree> ExpressionTreePtr;

}}}

#endif