using NovinMeyar.Technical.Domain.Contracts;
using NovinMeyar.Technical.Domain.Entities;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace NovinMeyar.Technical.Test
{
    public class BaseInformationServiceTest : BaseConfig
    {

        #region SearchAsync

        [Test]
        public async Task check_SearchAsync_action_by_id_that_has_valid_value_test()
        {
            var searchModel = new BaseInformationSearch { Id = 1 };
            var result = await this.BaseInformationService.SearchAsync(searchModel);
            Assert.IsTrue(result.Succeed);

            searchModel = new BaseInformationSearch { Id = null };
            result = await this.BaseInformationService.SearchAsync(searchModel);
            Assert.IsTrue(result.Succeed);
        }

        [Test]
        public async Task check_SearchAsync_action_by_id_that_has_invalid_value_test()
        {
            var searchModel = new BaseInformationSearch { Id = 0 };
            var result = await this.BaseInformationService.SearchAsync(searchModel);
            Assert.IsFalse(result.Succeed);

            searchModel.Id = -1;
            result = await this.BaseInformationService.SearchAsync(searchModel);
            Assert.IsFalse(result.Succeed);
        }

        [Test]
        public async Task check_SearchAsync_action_by_code_that_has_valid_value_test()
        {
            var searchModel = new BaseInformationSearch { Code = "001" };
            var result = await this.BaseInformationService.SearchAsync(searchModel);
            Assert.IsTrue(result.Succeed);

            searchModel = new BaseInformationSearch { Code = null };
            result = await this.BaseInformationService.SearchAsync(searchModel);
            Assert.IsTrue(result.Succeed);
        }

        [Test]
        public async Task check_SearchAsync_action_by_code_that_has_invalid_value_test()
        {
            var searchModel = new BaseInformationSearch { Code = "" };
            var result = await this.BaseInformationService.SearchAsync(searchModel);
            Assert.IsFalse(result.Succeed);
        }

        [Test]
        public async Task check_SearchAsync_action_by_name_that_has_valid_value_test()
        {
            var searchModel = new BaseInformationSearch { Name = "david" };
            var result = await this.BaseInformationService.SearchAsync(searchModel);
            Assert.IsTrue(result.Succeed);

            searchModel = new BaseInformationSearch { Name = null };
            result = await this.BaseInformationService.SearchAsync(searchModel);
            Assert.IsTrue(result.Succeed);
        }

        [Test]
        public async Task check_SearchAsync_action_by_name_that_has_invalid_value_test()
        {
            var searchModel = new BaseInformationSearch { Name = "" };
            var result = await this.BaseInformationService.SearchAsync(searchModel);
            Assert.IsFalse(result.Succeed);
        }

        [Test]
        public async Task check_SearchAsync_action_by_parentId_that_has_valid_value_test()
        {
            var searchModel = new BaseInformationSearch { ParentId = 1 };
            var result = await this.BaseInformationService.SearchAsync(searchModel);
            Assert.IsTrue(result.Succeed);

            searchModel = new BaseInformationSearch { ParentId = null };
            result = await this.BaseInformationService.SearchAsync(searchModel);
            Assert.IsTrue(result.Succeed);
        }

        [Test]
        public async Task check_SearchAsync_action_by_parentId_that_has_invalid_value_test()
        {
            var searchModel = new BaseInformationSearch { ParentId = 0 };
            var result = await this.BaseInformationService.SearchAsync(searchModel);
            Assert.IsFalse(result.Succeed);

            searchModel.ParentId = -1;
            result = await this.BaseInformationService.SearchAsync(searchModel);
            Assert.IsFalse(result.Succeed);
        }

        [Test]
        public async Task check_SearchAsync_action_by_propertyId_that_has_valid_value_test()
        {
            var searchModel = new BaseInformationSearch { PropertyId = 1 };
            var result = await this.BaseInformationService.SearchAsync(searchModel);
            Assert.IsTrue(result.Succeed);

            searchModel = new BaseInformationSearch { PropertyId = null };
            result = await this.BaseInformationService.SearchAsync(searchModel);
            Assert.IsTrue(result.Succeed);
        }

        [Test]
        public async Task check_SearchAsync_action_by_propertyId_that_has_invalid_value_test()
        {
            var searchModel = new BaseInformationSearch { PropertyId = 0 };
            var result = await this.BaseInformationService.SearchAsync(searchModel);
            Assert.IsFalse(result.Succeed);

            searchModel.PropertyId = -1;
            result = await this.BaseInformationService.SearchAsync(searchModel);
            Assert.IsFalse(result.Succeed);
        }

        [Test]
        public async Task check_SearchAsync_action_by_elevatorTypeId_that_has_valid_value_test()
        {
            var searchModel = new BaseInformationSearch { ElevatorTypeId = 1 };
            var result = await this.BaseInformationService.SearchAsync(searchModel);
            Assert.IsTrue(result.Succeed);

            searchModel = new BaseInformationSearch { ElevatorTypeId = null };
            result = await this.BaseInformationService.SearchAsync(searchModel);
            Assert.IsTrue(result.Succeed);
        }

        [Test]
        public async Task check_SearchAsync_action_by_elevatorTypeId_that_has_invalid_value_test()
        {
            var searchModel = new BaseInformationSearch { ElevatorTypeId = 0 };
            var result = await this.BaseInformationService.SearchAsync(searchModel);
            Assert.IsFalse(result.Succeed);

            searchModel.ElevatorTypeId = -1;
            result = await this.BaseInformationService.SearchAsync(searchModel);
            Assert.IsFalse(result.Succeed);
        }

        [Test]
        public async Task check_SearchAsync_action_by_invalid_search_model_test()
        {
            var result = await this.BaseInformationService.SearchAsync(null);
            Assert.IsFalse(result.Succeed);
        }
        #endregion

        #region GetObjectDetailItemsAsync

        [Test]
        public async Task check_GetObjectDetailItemsAsync_action_by_objectDetailId_that_has_valid_value_test()
        {
            var result = await this.BaseInformationService.GetObjectDetailItemsAsync(1);
            Assert.IsTrue(result.Succeed);
        }

        [Test]
        public async Task check_GetObjectDetailItemsAsync_action_by_objectDetailId_that_has_invalid_value_test()
        {
            var result = await this.BaseInformationService.GetObjectDetailItemsAsync(0);
            Assert.IsFalse(result.Succeed);

            result = await this.BaseInformationService.GetObjectDetailItemsAsync(-1);
            Assert.IsFalse(result.Succeed);
        }
        #endregion

        #region SearchPropertyAsync

        [Test]
        public async Task check_SearchPropertyAsync_action_by_name_that_has_valid_value_test()
        {
            var searchModel = new SearchProperty { Name = "david" };
            var result = await this.BaseInformationService.SearchPropertyAsync(searchModel);
            Assert.IsTrue(result.Succeed);

            searchModel = new SearchProperty { Name = null };
            result = await this.BaseInformationService.SearchPropertyAsync(searchModel);
            Assert.IsTrue(result.Succeed);
        }

        [Test]
        public async Task check_SearchPropertyAsync_action_by_name_that_has_invalid_value_test()
        {
            var searchModel = new SearchProperty { Name = "" };
            var result = await this.BaseInformationService.SearchPropertyAsync(searchModel);
            Assert.IsFalse(result.Succeed);
        }

        [Test]
        public async Task check_SearchPropertyAsync_action_by_type_that_has_valid_value_test()
        {
            var searchModel = new SearchProperty { Type = "david" };
            var result = await this.BaseInformationService.SearchPropertyAsync(searchModel);
            Assert.IsTrue(result.Succeed);

            searchModel = new SearchProperty { Type = null };
            result = await this.BaseInformationService.SearchPropertyAsync(searchModel);
            Assert.IsTrue(result.Succeed);
        }

        [Test]
        public async Task check_SearchPropertyAsync_action_by_type_that_has_invalid_value_test()
        {
            var searchModel = new SearchProperty { Type = "" };
            var result = await this.BaseInformationService.SearchPropertyAsync(searchModel);
            Assert.IsFalse(result.Succeed);
        }
        #endregion

        #region SaveAsync

        [Test]
        public async Task check_SaveAsync_action_by_name_that_has_valid_value_test()
        {
            var rnd = new Random();
            var objectDetail = new ObjectDetail { Name = "David" + rnd.Next(1000, 230000), CreateDate = DateTime.Now, UserCreatorName = "admin", Level = 0, Deleted = false };
            var result = await this.BaseInformationService.SaveAsync(objectDetail, "admin");
            Assert.IsTrue(result.Succeed);
        }

        [Test]
        public async Task check_SaveAsync_action_by_name_that_has_invalid_value_test()
        {
            var objectDetail = new ObjectDetail { Name = "" };
            var result = await this.BaseInformationService.SaveAsync(objectDetail, "admin");
            Assert.IsFalse(result.Succeed);
        }

        [Test]
        public async Task check_SaveAsync_action_by_parentId_that_has_valid_value_test()
        {
            var rnd = new Random();
            var objectDetail = new ObjectDetail { Name="Test"+rnd.Next(1000,230000), CreateDate=DateTime.Now, UserCreatorName="admin", Level=0, Deleted=false, ParentId=1 };
            var result = await this.BaseInformationService.SaveAsync(objectDetail, "admin");
            Assert.IsTrue(result.Succeed);
        }

        [Test]
        public async Task check_SaveAsync_action_by_parentId_that_has_invalid_value_test()
        {
            var objectDetail = new ObjectDetail { ParentId = 0 };
            var result = await this.BaseInformationService.SaveAsync(objectDetail, "admin");
            Assert.IsFalse(result.Succeed);

            objectDetail = new ObjectDetail { ParentId = -1 };
            result = await this.BaseInformationService.SaveAsync(objectDetail, "admin");
            Assert.IsFalse(result.Succeed);
        }

        [Test]
        public async Task check_SaveAsync_action_by_elevatorTypeId_that_has_valid_value_test()
        {
            var rnd = new Random();
            var objectDetail = new ObjectDetail { Name = "Test" + rnd.Next(1000, 230000), CreateDate = DateTime.Now, UserCreatorName = "admin", Level = 0, Deleted = false, ElevatorTypeId = 1 };
            var result = await this.BaseInformationService.SaveAsync(objectDetail, "admin");
            Assert.IsTrue(result.Succeed);
        }

        [Test]
        public async Task check_SaveAsync_action_by_elevatorTypeId_that_has_invalid_value_test()
        {
            var objectDetail = new ObjectDetail { ElevatorTypeId = 0 };
            var result = await this.BaseInformationService.SaveAsync(objectDetail, "admin");
            Assert.IsFalse(result.Succeed);

            objectDetail = new ObjectDetail { ElevatorTypeId = -1 };
            result = await this.BaseInformationService.SaveAsync(objectDetail, "admin");
            Assert.IsFalse(result.Succeed);
        }

        #endregion

        #region DeletePropertyAsync

        [Test]
        public async Task check_DeletePropertyAsync_action_test()
        {
            var result = await this.BaseInformationService.DeletePropertyAsync(0, "");
            Assert.IsFalse(result.Succeed);
        }
        #endregion

        #region DeactiveAsync

        [Test]
        public async Task check_DeactiveAsync_action_test()
        {
            var result = await this.BaseInformationService.DeactiveAsync(0, "");
            Assert.IsFalse(result.Succeed);
        }
        #endregion

        #region DeactiveObjectDetailPropertyAsync

        [Test]
        public async Task check_DeactiveObjectDetailPropertyAsync_action_test()
        {
            var result = await this.BaseInformationService.DeactiveObjectDetailPropertyAsync(0, "");
            Assert.IsFalse(result.Succeed);
        }
        #endregion

        #region SavePropertyAsync

        [Test]
        public async Task check_SavePropertyAsync_action_by_name_that_has_valid_value_test()
        {
            var rnd = new Random();
            var objectDetail = new Property { Name = "Property" + rnd.Next(1, 2000), Type="test", CreateDate = DateTime.Now, UserCreatorName = "admin", Deleted = false };
            var result = await this.BaseInformationService.SavePropertyAsync(objectDetail, "admin");
            Assert.IsTrue(result.Succeed);
        }

        [Test]
        public async Task check_SavePropertyAsync_action_by_name_that_has_invalid_value_test()
        {
            var objectDetail = new Property { Name = "", Type="type" };
            var result = await this.BaseInformationService.SavePropertyAsync(objectDetail, "admin");
            Assert.IsFalse(result.Succeed);
        }

        [Test]
        public async Task check_SavePropertyAsync_action_by_type_that_has_valid_value_test()
        {
            var rnd = new Random();
            var objectDetail = new Property { Name = "Property2" + rnd.Next(2, 2000), Type="test", CreateDate = DateTime.Now, UserCreatorName = "admin", Deleted = false};
            var result = await this.BaseInformationService.SavePropertyAsync(objectDetail, "admin");
            Assert.IsTrue(result.Succeed);
        }

        [Test]
        public async Task check_SavePropertyAsync_action_by_type_that_has_invalid_value_test()
        {
            var result = await this.BaseInformationService.SavePropertyAsync(null, "admin");
            Assert.IsFalse(result.Succeed);

            var objectDetail = new Property { Name="Property3", Type = "" };
            result = await this.BaseInformationService.SavePropertyAsync(objectDetail, "admin");
            Assert.IsFalse(result.Succeed);
        }

        #endregion

        #region GetInspectionTypesAsync

        [Test]
        public async Task check_GetInspectionTypesAsync_action_test()
        {
            var result = await this.BaseInformationService.GetInspectionTypesAsync();
            Assert.IsTrue(result.Succeed);
        }
        #endregion

        #region GetLatestCertificateTypesAsync

        [Test]
        public async Task check_GetLatestCertificateTypesAsync_action_test()
        {
            var result = await this.BaseInformationService.GetLatestCertificateTypesAsync();
            Assert.IsTrue(result.Succeed);
        }
        #endregion

        #region GetElevatorTypesAsync

        [Test]
        public async Task check_GetElevatorTypesAsync_action_test()
        {
            var result = await this.BaseInformationService.GetElevatorTypesAsync();
            Assert.IsTrue(result.Succeed);
        }
        #endregion

        #region GetTreeAsync

        [Test]
        public async Task check_GetTreeAsync_action_test()
        {
            var result = await this.BaseInformationService.GetTreeAsync();
            Assert.IsTrue(result.Succeed);
        }
        #endregion

        #region GetBrakeTypesAsync

        [Test]
        public async Task check_GetBrakeTypesAsync_action_test()
        {
            var result = await this.BaseInformationService.GetBrakeTypesAsync();
            Assert.IsTrue(result.Succeed);
        }
        #endregion

        #region GetCabinAntiShockTypesAsync

        [Test]
        public async Task check_GetCabinAntiShockTypesAsync_action_test()
        {
            var result = await this.BaseInformationService.GetCabinAntiShockTypesAsync();
            Assert.IsTrue(result.Succeed);
        }
        #endregion

        #region GetCounterWeightAntiShockTypesAsync

        [Test]
        public async Task check_GetCounterWeightAntiShockTypesAsync_action_test()
        {
            var result = await this.BaseInformationService.GetCounterWeightAntiShockTypesAsync();
            Assert.IsTrue(result.Succeed);
        }
        #endregion

        #region GetCounterWeightTypesAsync

        [Test]
        public async Task check_GetCounterWeightTypesAsync_action_test()
        {
            var result = await this.BaseInformationService.GetCounterWeightTypesAsync();
            Assert.IsTrue(result.Succeed);
        }
        #endregion

        #region GetDoorTypesAsync

        [Test]
        public async Task check_GetDoorTypesAsync_action_test()
        {
            var result = await this.BaseInformationService.GetDoorTypesAsync(false);
            Assert.IsTrue(result.Succeed);
        }
        #endregion

        #region GetInstallationTypesAsync

        [Test]
        public async Task check_GetInstallationTypesAsync_action_test()
        {
            var result = await this.BaseInformationService.GetInstallationTypesAsync();
            Assert.IsTrue(result.Succeed);
        }
        #endregion

        #region GetLocationTypesAsync

        [Test]
        public async Task check_GetLocationTypesAsync_action_test()
        {
            var result = await this.BaseInformationService.GetLocationTypesAsync(1);
            Assert.IsTrue(result.Succeed);

            result = await this.BaseInformationService.GetLocationTypesAsync(0);
            Assert.IsFalse(result.Succeed);
        }
        #endregion

        #region FindLocationTypeAsync

        [Test]
        public async Task check_FindLocationTypeAsync_action_by_valid_value_test()
        {
            var result = await this.BaseInformationService.FindLocationTypeAsync("Left-Up-Vertical");
            Assert.IsTrue(result.Succeed);
        }

        [Test]
        public async Task check_FindLocationTypeAsync_action_by_invalid_value_test()
        {
            var result = await this.BaseInformationService.FindLocationTypeAsync(null);
            Assert.IsFalse(result.Succeed);

            result = await this.BaseInformationService.FindLocationTypeAsync("");
            Assert.IsFalse(result.Succeed);

            result = await this.BaseInformationService.FindLocationTypeAsync("fgfhg");
            Assert.IsFalse(result.Succeed);
        }
        #endregion

        #region GetWeightShoesTypesAsync

        [Test]
        public async Task check_GetWeightShoesTypesAsync_action_test()
        {
            var result = await this.BaseInformationService.GetWeightShoesTypesAsync();
            Assert.IsTrue(result.Succeed);
        }
        #endregion
    }
}