using NovinMeyar.Technical.Domain.Contracts;
using NUnit.Framework;
using System.Threading.Tasks;

namespace NovinMeyar.Technical.Test
{
    public class FastRegisrationRequestServiceTest : BaseConfig
    {

        #region SearchAsync

        [Test]
        public async Task check_SearchAsync_action_by_id_that_has_valid_value_test()
        {
            var searchModel = new FastRegistrationSearch { Id = "1" };
            var result = await this.FastRegisrationRequestService.SearchAsync(searchModel, 1, false, "Administrator", null);
            Assert.IsTrue(result.Succeed);
            result = await this.FastRegisrationRequestService.SearchAsync(searchModel, 1, true, "Administrator", null);
            Assert.IsTrue(result.Succeed);

            searchModel = new FastRegistrationSearch { Id = null };
            result = await this.FastRegisrationRequestService.SearchAsync(searchModel, 1, false, "Administrator", null);
            Assert.IsTrue(result.Succeed);
            result = await this.FastRegisrationRequestService.SearchAsync(searchModel, 1, true, "Administrator", null);
            Assert.IsTrue(result.Succeed);
        }

        [Test]
        public async Task check_SearchAsync_action_by_id_that_has_invalid_value_test()
        {
            var searchModel = new FastRegistrationSearch { Id = "0" };
            var result = await this.FastRegisrationRequestService.SearchAsync(searchModel, 1, false, "Administrator", null);
            Assert.IsFalse(result.Succeed);
            result = await this.FastRegisrationRequestService.SearchAsync(searchModel, 1, true, "Administrator", null);
            Assert.IsFalse(result.Succeed);

            searchModel.Id = "-1";
            result = await this.FastRegisrationRequestService.SearchAsync(searchModel, 1, false, "Administrator", null);
            Assert.IsFalse(result.Succeed);
            result = await this.FastRegisrationRequestService.SearchAsync(searchModel, 1, true, "Administrator", null);
            Assert.IsFalse(result.Succeed);
        }

        [Test]
        public async Task check_SearchAsync_action_by_InstallatinCompanyId_that_has_valid_value_test()
        {
            var searchModel = new FastRegistrationSearch { InstallatinCompanyId = 1 };

            var result = await this.FastRegisrationRequestService.SearchAsync(searchModel, 1, false, "Administrator", null);
            Assert.IsTrue(result.Succeed);
            result = await this.FastRegisrationRequestService.SearchAsync(searchModel, 1, true, "Administrator", null);
            Assert.IsTrue(result.Succeed);

            searchModel.InstallatinCompanyId = null;
            result = await this.FastRegisrationRequestService.SearchAsync(searchModel, 1, false, "Administrator", null);
            Assert.IsTrue(result.Succeed);
            result = await this.FastRegisrationRequestService.SearchAsync(searchModel, 1, true, "Administrator", null);
            Assert.IsTrue(result.Succeed);
        }

        [Test]
        public async Task check_SearchAsync_action_by_InstallatinCompanyId_that_has_invalid_value_test()
        {
            var searchModel = new FastRegistrationSearch { InstallatinCompanyId = 0 };
            var result = await this.FastRegisrationRequestService.SearchAsync(searchModel, 1, false, "Administrator", null);
            Assert.IsFalse(result.Succeed);
            result = await this.FastRegisrationRequestService.SearchAsync(searchModel, 1, true, "Administrator", null);
            Assert.IsFalse(result.Succeed);

            searchModel.InstallatinCompanyId = -1;
            result = await this.FastRegisrationRequestService.SearchAsync(searchModel, 1, false, "Administrator", null);
            Assert.IsFalse(result.Succeed);
            result = await this.FastRegisrationRequestService.SearchAsync(searchModel, 1, true, "Administrator", null);
            Assert.IsFalse(result.Succeed);
        }

        [Test]
        public async Task check_SearchAsync_action_by_DocumentNumber_that_has_valid_value_test()
        {
            var searchModel = new FastRegistrationSearch { DocumentNumber = "001" };
            var result = await this.FastRegisrationRequestService.SearchAsync(searchModel, 1, false, "Administrator", null);
            Assert.IsTrue(result.Succeed);
            result = await this.FastRegisrationRequestService.SearchAsync(searchModel, 1, true, "Administrator", null);
            Assert.IsTrue(result.Succeed);

            searchModel.DocumentNumber = null;
            result = await this.FastRegisrationRequestService.SearchAsync(searchModel, 1, false, "Administrator", null);
            Assert.IsTrue(result.Succeed);
            result = await this.FastRegisrationRequestService.SearchAsync(searchModel, 1, true, "Administrator", null);
            Assert.IsTrue(result.Succeed);
        }

        [Test]
        public async Task check_SearchAsync_action_by_DocumentNumber_that_has_invalid_value_test()
        {
            var searchModel = new FastRegistrationSearch { DocumentNumber = "" };
            var result = await this.FastRegisrationRequestService.SearchAsync(searchModel, 1, false, "Administrator", null);
            Assert.IsFalse(result.Succeed);
        }

        [Test]
        public async Task check_SearchAsync_action_by_BuildingCertificateNo_that_has_valid_value_test()
        {
            var searchModel = new FastRegistrationSearch { BuildingCertificateNo = "001" };
            var result = await this.FastRegisrationRequestService.SearchAsync(searchModel, 1, false, "Administrator", null);
            Assert.IsTrue(result.Succeed);
            result = await this.FastRegisrationRequestService.SearchAsync(searchModel, 1, true, "Administrator", null);
            Assert.IsTrue(result.Succeed);

            searchModel.BuildingCertificateNo = null;
            result = await this.FastRegisrationRequestService.SearchAsync(searchModel, 1, false, "Administrator", null);
            Assert.IsTrue(result.Succeed);
            result = await this.FastRegisrationRequestService.SearchAsync(searchModel, 1, true, "Administrator", null);
            Assert.IsTrue(result.Succeed);
        }

        [Test]
        public async Task check_SearchAsync_action_by_BuildingCertificateNo_that_has_invalid_value_test()
        {
            var searchModel = new FastRegistrationSearch { BuildingCertificateNo = "" };
            var result = await this.FastRegisrationRequestService.SearchAsync(searchModel, 1, false, "Administrator", null);
            Assert.IsFalse(result.Succeed);
        }

        [Test]
        public async Task check_SearchAsync_action_by_ResponsibleFullName_that_has_valid_value_test()
        {
            var searchModel = new FastRegistrationSearch { ResponsibleFullName = "david" };
            var result = await this.FastRegisrationRequestService.SearchAsync(searchModel, 1, false, "Administrator", null);
            Assert.IsTrue(result.Succeed);
            result = await this.FastRegisrationRequestService.SearchAsync(searchModel, 1, true, "Administrator", null);
            Assert.IsTrue(result.Succeed);

            searchModel.ResponsibleFullName = null;
            result = await this.FastRegisrationRequestService.SearchAsync(searchModel, 1, false, "Administrator", null);
            Assert.IsTrue(result.Succeed);
            result = await this.FastRegisrationRequestService.SearchAsync(searchModel, 1, true, "Administrator", null);
            Assert.IsTrue(result.Succeed);
        }

        [Test]
        public async Task check_SearchAsync_action_by_ResponsibleFullName_that_has_invalid_value_test()
        {
            var searchModel = new FastRegistrationSearch { ResponsibleFullName = "" };
            var result = await this.FastRegisrationRequestService.SearchAsync(searchModel, 1, false, "Administrator", null);
            Assert.IsFalse(result.Succeed);
        }

        #endregion

    }
}
