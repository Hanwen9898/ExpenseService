using Expense.Service;
using Expense.Service.Exceptions;
using Expense.Service.Expense;
using Expense.Service.Projects;
using System;
using Xunit;

namespace Expense.Service.Test
{
    public class ExpenseServiceTest
    {
        [Fact]
        public void Should_return_internal_expense_type_if_project_is_internal()
        {
            // given
            Project project = new Project(ProjectType.INTERNAL, "Internal project");
            // when
            ExpenseType expensetype = ExpenseService.GetExpenseCodeByProjectTypeAndName(project);
            // then
            Assert.Equal(ExpenseType.INTERNAL_PROJECT_EXPENSE, expensetype);
        }

        [Fact]
        public void Should_return_expense_type_A_if_project_is_external_and_name_is_project_A()
        {
            // given
            Project project = new Project(ProjectType.EXTERNAL, "Project A");
            // when
            ExpenseType expensetype = ExpenseService.GetExpenseCodeByProjectTypeAndName(project);
            // then
            Assert.Equal(ExpenseType.EXPENSE_TYPE_A, expensetype);
        }

        [Fact]
        public void Should_return_expense_type_B_if_project_is_external_and_name_is_project_B()
        {
            // given
            Project project = new Project(ProjectType.EXTERNAL, "Project B");
            // when
            ExpenseType expensetype = ExpenseService.GetExpenseCodeByProjectTypeAndName(project);
            // then
            Assert.Equal(ExpenseType.EXPENSE_TYPE_B, expensetype);
        }

        [Fact]
        public void Should_return_other_expense_type_if_project_is_external_and_has_other_name()
        {
            Project project = new Project(ProjectType.EXTERNAL, "Project EEEEE");
            // when
            ExpenseType expensetype = ExpenseService.GetExpenseCodeByProjectTypeAndName(project);
            // then
            Assert.Equal(ExpenseType.OTHER_EXPENSE, expensetype);
        }

        [Fact]
        public void Should_throw_unexpected_project_exception_if_project_is_invalid()
        {
            Project project = new Project(ProjectType.UNEXPECTED_PROJECT_TYPE, "UNEXPECTED_PROJECT_TYPE");
            // when
            Action action = () => ExpenseService.GetExpenseCodeByProjectTypeAndName(project);
            //ExpenseService.GetExpenseCodeByProjectTypeAndName(project);
            // then
            Assert.Throws<UnexpectedProjectTypeException>(action);
        }
    }
}