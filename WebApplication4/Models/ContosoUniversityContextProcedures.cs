﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Threading.Tasks;
using WebApplication4.Models;

namespace WebApplication4.Models
{
    public partial class ContosoUniversityContextProcedures
    {
        private readonly ContosoUniversityContext _context;

        public ContosoUniversityContextProcedures(ContosoUniversityContext context)
        {
            _context = context;
        }

        public async Task<int> Department_Delete(int? DepartmentID, byte[] RowVersion_Original, OutputParameter<int> returnValue = null)
        {
            var parameterDepartmentID = new SqlParameter
            {
                ParameterName = "DepartmentID",
                Value = DepartmentID ?? Convert.DBNull,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var parameterRowVersion_Original = new SqlParameter
            {
                ParameterName = "RowVersion_Original",
                Value = RowVersion_Original ?? Convert.DBNull,
                SqlDbType = System.Data.SqlDbType.Timestamp,
            };

            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var _ = await _context.Database.ExecuteSqlRawAsync("EXEC @returnValue = [dbo].[Department_Delete] @DepartmentID, @RowVersion_Original", parameterDepartmentID, parameterRowVersion_Original, parameterreturnValue);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public async Task<Department_InsertResult[]> Department_Insert(string Name, decimal? Budget, DateTime? StartDate, int? InstructorID, OutputParameter<int> returnValue = null)
        {
            var parameterName = new SqlParameter
            {
                ParameterName = "Name",
                Size = 100,
                Value = Name ?? Convert.DBNull,
                SqlDbType = System.Data.SqlDbType.NVarChar,
            };

            var parameterBudget = new SqlParameter
            {
                ParameterName = "Budget",
                Value = Budget ?? Convert.DBNull,
                SqlDbType = System.Data.SqlDbType.Money,
            };

            var parameterStartDate = new SqlParameter
            {
                ParameterName = "StartDate",
                Value = StartDate ?? Convert.DBNull,
                SqlDbType = System.Data.SqlDbType.DateTime,
            };

            var parameterInstructorID = new SqlParameter
            {
                ParameterName = "InstructorID",
                Value = InstructorID ?? Convert.DBNull,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var _ = await _context.SqlQuery<Department_InsertResult>("EXEC @returnValue = [dbo].[Department_Insert] @Name, @Budget, @StartDate, @InstructorID", parameterName, parameterBudget, parameterStartDate, parameterInstructorID, parameterreturnValue);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public async Task<Department_UpdateResult[]> Department_Update(int? DepartmentID, string Name, decimal? Budget, DateTime? StartDate, int? InstructorID, byte[] RowVersion_Original, OutputParameter<int> returnValue = null)
        {
            var parameterDepartmentID = new SqlParameter
            {
                ParameterName = "DepartmentID",
                Value = DepartmentID ?? Convert.DBNull,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var parameterName = new SqlParameter
            {
                ParameterName = "Name",
                Size = 100,
                Value = Name ?? Convert.DBNull,
                SqlDbType = System.Data.SqlDbType.NVarChar,
            };

            var parameterBudget = new SqlParameter
            {
                ParameterName = "Budget",
                Value = Budget ?? Convert.DBNull,
                SqlDbType = System.Data.SqlDbType.Money,
            };

            var parameterStartDate = new SqlParameter
            {
                ParameterName = "StartDate",
                Value = StartDate ?? Convert.DBNull,
                SqlDbType = System.Data.SqlDbType.DateTime,
            };

            var parameterInstructorID = new SqlParameter
            {
                ParameterName = "InstructorID",
                Value = InstructorID ?? Convert.DBNull,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var parameterRowVersion_Original = new SqlParameter
            {
                ParameterName = "RowVersion_Original",
                Value = RowVersion_Original ?? Convert.DBNull,
                SqlDbType = System.Data.SqlDbType.Timestamp,
            };

            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var _ = await _context.SqlQuery<Department_UpdateResult>("EXEC @returnValue = [dbo].[Department_Update] @DepartmentID, @Name, @Budget, @StartDate, @InstructorID, @RowVersion_Original", parameterDepartmentID, parameterName, parameterBudget, parameterStartDate, parameterInstructorID, parameterRowVersion_Original, parameterreturnValue);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public async Task<GetCourseReportResult[]> GetCourseReport(int? CourseID, OutputParameter<int> returnValue = null)
        {
            var parameterCourseID = new SqlParameter
            {
                ParameterName = "CourseID",
                Value = CourseID ?? Convert.DBNull,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var _ = await _context.SqlQuery<GetCourseReportResult>("EXEC @returnValue = [dbo].[GetCourseReport] @CourseID", parameterCourseID, parameterreturnValue);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public async Task<int> sp_alterdiagram(string diagramname, int? owner_id, int? version, byte[] definition, OutputParameter<int> returnValue = null)
        {
            var parameterdiagramname = new SqlParameter
            {
                ParameterName = "diagramname",
                Size = 256,
                Value = diagramname ?? Convert.DBNull,
                SqlDbType = System.Data.SqlDbType.NVarChar,
            };

            var parameterowner_id = new SqlParameter
            {
                ParameterName = "owner_id",
                Value = owner_id ?? Convert.DBNull,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var parameterversion = new SqlParameter
            {
                ParameterName = "version",
                Value = version ?? Convert.DBNull,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var parameterdefinition = new SqlParameter
            {
                ParameterName = "definition",
                Value = definition ?? Convert.DBNull,
                SqlDbType = System.Data.SqlDbType.VarBinary,
            };

            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var _ = await _context.Database.ExecuteSqlRawAsync("EXEC @returnValue = [dbo].[sp_alterdiagram] @diagramname, @owner_id, @version, @definition", parameterdiagramname, parameterowner_id, parameterversion, parameterdefinition, parameterreturnValue);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public async Task<int> sp_creatediagram(string diagramname, int? owner_id, int? version, byte[] definition, OutputParameter<int> returnValue = null)
        {
            var parameterdiagramname = new SqlParameter
            {
                ParameterName = "diagramname",
                Size = 256,
                Value = diagramname ?? Convert.DBNull,
                SqlDbType = System.Data.SqlDbType.NVarChar,
            };

            var parameterowner_id = new SqlParameter
            {
                ParameterName = "owner_id",
                Value = owner_id ?? Convert.DBNull,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var parameterversion = new SqlParameter
            {
                ParameterName = "version",
                Value = version ?? Convert.DBNull,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var parameterdefinition = new SqlParameter
            {
                ParameterName = "definition",
                Value = definition ?? Convert.DBNull,
                SqlDbType = System.Data.SqlDbType.VarBinary,
            };

            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var _ = await _context.Database.ExecuteSqlRawAsync("EXEC @returnValue = [dbo].[sp_creatediagram] @diagramname, @owner_id, @version, @definition", parameterdiagramname, parameterowner_id, parameterversion, parameterdefinition, parameterreturnValue);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public async Task<int> sp_dropdiagram(string diagramname, int? owner_id, OutputParameter<int> returnValue = null)
        {
            var parameterdiagramname = new SqlParameter
            {
                ParameterName = "diagramname",
                Size = 256,
                Value = diagramname ?? Convert.DBNull,
                SqlDbType = System.Data.SqlDbType.NVarChar,
            };

            var parameterowner_id = new SqlParameter
            {
                ParameterName = "owner_id",
                Value = owner_id ?? Convert.DBNull,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var _ = await _context.Database.ExecuteSqlRawAsync("EXEC @returnValue = [dbo].[sp_dropdiagram] @diagramname, @owner_id", parameterdiagramname, parameterowner_id, parameterreturnValue);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public async Task<int> sp_helpdiagramdefinition(string diagramname, int? owner_id, OutputParameter<int> returnValue = null)
        {
            var parameterdiagramname = new SqlParameter
            {
                ParameterName = "diagramname",
                Size = 256,
                Value = diagramname ?? Convert.DBNull,
                SqlDbType = System.Data.SqlDbType.NVarChar,
            };

            var parameterowner_id = new SqlParameter
            {
                ParameterName = "owner_id",
                Value = owner_id ?? Convert.DBNull,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var _ = await _context.Database.ExecuteSqlRawAsync("EXEC @returnValue = [dbo].[sp_helpdiagramdefinition] @diagramname, @owner_id", parameterdiagramname, parameterowner_id, parameterreturnValue);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public async Task<int> sp_helpdiagrams(string diagramname, int? owner_id, OutputParameter<int> returnValue = null)
        {
            var parameterdiagramname = new SqlParameter
            {
                ParameterName = "diagramname",
                Size = 256,
                Value = diagramname ?? Convert.DBNull,
                SqlDbType = System.Data.SqlDbType.NVarChar,
            };

            var parameterowner_id = new SqlParameter
            {
                ParameterName = "owner_id",
                Value = owner_id ?? Convert.DBNull,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var _ = await _context.Database.ExecuteSqlRawAsync("EXEC @returnValue = [dbo].[sp_helpdiagrams] @diagramname, @owner_id", parameterdiagramname, parameterowner_id, parameterreturnValue);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public async Task<int> sp_renamediagram(string diagramname, int? owner_id, string new_diagramname, OutputParameter<int> returnValue = null)
        {
            var parameterdiagramname = new SqlParameter
            {
                ParameterName = "diagramname",
                Size = 256,
                Value = diagramname ?? Convert.DBNull,
                SqlDbType = System.Data.SqlDbType.NVarChar,
            };

            var parameterowner_id = new SqlParameter
            {
                ParameterName = "owner_id",
                Value = owner_id ?? Convert.DBNull,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var parameternew_diagramname = new SqlParameter
            {
                ParameterName = "new_diagramname",
                Size = 256,
                Value = new_diagramname ?? Convert.DBNull,
                SqlDbType = System.Data.SqlDbType.NVarChar,
            };

            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var _ = await _context.Database.ExecuteSqlRawAsync("EXEC @returnValue = [dbo].[sp_renamediagram] @diagramname, @owner_id, @new_diagramname", parameterdiagramname, parameterowner_id, parameternew_diagramname, parameterreturnValue);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public async Task<int> sp_upgraddiagrams(OutputParameter<int> returnValue = null)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var _ = await _context.Database.ExecuteSqlRawAsync("EXEC @returnValue = [dbo].[sp_upgraddiagrams]", parameterreturnValue);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }
    }
}
