using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace TestXUnitYogaAshram
{
    [TestCaseOrderer("TestXUnitYogaAshram.AlphabeticalOrderer", "TestXUnitYogaAshram")]
    public class ChiefPageTest : IDisposable
    {
        private readonly IWebDriver _driver;
        private readonly BasicSteps _basicSteps;

        public ChiefPageTest()
        {
            _driver = new ChromeDriver();
            _basicSteps = new BasicSteps(_driver);
        }

        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }

        [Fact]
        public void LoginWrongModelDataReturnsMessageTest()
        {
            _basicSteps.GotoLoginPage();
            _basicSteps.FillTextField("Email", "dir@gmail.com");
            _basicSteps.FillTextField("Password", "dir@gmail.com");
            _basicSteps.ClickById("submit");
            Thread.Sleep(2000);
            Assert.True(_basicSteps
                .IsElementFound("Не корректный пароль и(или) аутентификатор"));
        }

        [Fact]
        public void LoginEmptyEmailDataReturnsMessageTest()
        {
            _basicSteps.GotoLoginPage();
            _basicSteps.FillTextField("Email", String.Empty);
            _basicSteps.FillTextField("Password", "wrong@Password");
            _basicSteps.ClickById("submit");
            Thread.Sleep(2000);
            Assert.True(_basicSteps
                .IsElementFound("Введите логин или почту"));
        }

        [Fact]
        public void LoginCorrectDataReturnsSuccessAuthTest()
        {
            _basicSteps.GotoLoginPage();
            _basicSteps.FillTextField("Email", "dir@gmail.com");
            _basicSteps.FillTextField("Password", "12345678910");
            _basicSteps.ClickById("submit");
            Thread.Sleep(1000);
            Assert.True(_basicSteps
                .IsElementFound("Директор"));
        }

        [Fact]
        public void CheckSubscriptionsPageTest()
        {
            LoginCorrectDataReturnsSuccessAuthTest();
            Thread.Sleep(1000);
            _basicSteps.ClickLink("Абонементы");
            _basicSteps.GoToUrl("http://localhost:5000/Membership");
            Assert.True(_basicSteps
                .IsElementFound("Список абонементов"));
        }

        [Fact]
        public void CreateGroupPageTest()
        {
            LoginCorrectDataReturnsSuccessAuthTest();
            Thread.Sleep(1000);
            _basicSteps.ClickLink("Создать группу");
            _basicSteps.GoToUrl("http://localhost:5000/Group/CreateGroup");
            Assert.True(_basicSteps
                .IsElementFound("Добавить новую группу"));
            _basicSteps.FillTextField("Name", "Aplle");
            _basicSteps.ClickById("submit");
            Assert.True(_basicSteps
                .IsElementFound("Добавить новую группу"));
        }

        [Fact]
        public void CheckEnterExitTest()
        {
            LoginCorrectDataReturnsSuccessAuthTest();
            _basicSteps.ClickById("chief");
            Thread.Sleep(1000);
            _basicSteps.ClickById("my_form");
            Thread.Sleep(1500);
            _basicSteps.GotoLoginPage();
            Assert.True(_basicSteps
                .IsElementFound("Аутентификация"));
        }

        [Fact]
        public void CreateEmployeeAdminTest()
        {
            LoginCorrectDataReturnsSuccessAuthTest();
            Thread.Sleep(1000);
            _basicSteps.ClickById("dropdown10");
            Thread.Sleep(1000);
            _basicSteps.ClickButton("Добавить работника");
            Thread.Sleep(1000);
            Assert.True(_basicSteps
                .IsElementFound("Новый работник"));
            _basicSteps.FillTextField("emplEmail", "Employye@emp.com");
            _basicSteps.FillTextField("emplNameSurname", "Employye Employye");
            _basicSteps.FillTextField("emplUserName", "Employye");
            _basicSteps.FillTextField("roleSelect", "Администратор");
            _basicSteps.ClickById("submitCreateEmpl");
            Thread.Sleep(1000);
            Assert.True(_basicSteps
                .IsElementFound("Директор"));
        }

        [Fact]
        public void CheckValidEmailEmployeeAdminTest()
        {
            LoginCorrectDataReturnsSuccessAuthTest();
            Thread.Sleep(1000);
            _basicSteps.ClickById("dropdown10");
            Thread.Sleep(1000);
            _basicSteps.ClickButton("Добавить работника");
            Thread.Sleep(1000);
            Assert.True(_basicSteps
                .IsElementFound("Новый работник"));
            _basicSteps.FillTextField("emplEmail", String.Empty);
            _basicSteps.FillTextField("emplNameSurname", "Employye Employye");
            _basicSteps.FillTextField("emplUserName", "Employye");
            _basicSteps.FillTextField("roleSelect", "Администратор");
            _basicSteps.ClickById("submitCreateEmpl");
            Thread.Sleep(1000);
            Assert.True(_basicSteps
                .IsElementFound("Введите почту"));
        }

        [Fact]
        public void CheckValidNameSurnameEmployeeAdminTest()
        {
            LoginCorrectDataReturnsSuccessAuthTest();
            Thread.Sleep(1000);
            _basicSteps.ClickById("dropdown10");
            Thread.Sleep(1000);
            _basicSteps.ClickButton("Добавить работника");
            Thread.Sleep(1000);
            Assert.True(_basicSteps
                .IsElementFound("Новый работник"));
            _basicSteps.FillTextField("emplEmail", "Employye@emp.com1");
            _basicSteps.FillTextField("emplNameSurname", String.Empty);
            _basicSteps.FillTextField("emplUserName", "Employye1");
            _basicSteps.FillTextField("roleSelect", "Администратор");
            _basicSteps.ClickById("submitCreateEmpl");
            Thread.Sleep(1000);
            Assert.True(_basicSteps
                .IsElementFound("Введите имя и фамилию"));
        }

        [Fact]
        public void CheckValidUserNameEmployeeAdminTest()
        {
            LoginCorrectDataReturnsSuccessAuthTest();
            Thread.Sleep(1000);
            _basicSteps.ClickById("dropdown10");
            Thread.Sleep(1000);
            _basicSteps.ClickButton("Добавить работника");
            Thread.Sleep(1000);
            Assert.True(_basicSteps
                .IsElementFound("Новый работник"));
            _basicSteps.FillTextField("emplEmail", "Employye@emp.com2");
            _basicSteps.FillTextField("emplNameSurname", "Employye Employye");
            _basicSteps.FillTextField("emplUserName", String.Empty);
            _basicSteps.FillTextField("roleSelect", "Администратор");
            _basicSteps.ClickById("submitCreateEmpl");
            Thread.Sleep(1000);
            Assert.True(_basicSteps
                .IsElementFound("Введите почту"));
        }

        [Fact]
        public void CreateEmployeeCoachTest()
        {
            LoginCorrectDataReturnsSuccessAuthTest();
            Thread.Sleep(1000);
            _basicSteps.ClickById("dropdown10");
            Thread.Sleep(1000);
            _basicSteps.ClickButton("Добавить работника");
            Thread.Sleep(1000);
            Assert.True(_basicSteps
                .IsElementFound("Новый работник"));
            _basicSteps.FillTextField("emplEmail", "Coach@coa.com");
            _basicSteps.FillTextField("emplNameSurname", "Coach Coach");
            _basicSteps.FillTextField("emplUserName", "Coach");
            _basicSteps.FillTextField("roleSelect", "Инструктор");
            _basicSteps.ClickById("submitCreateEmpl");
            Thread.Sleep(1000);
            Assert.True(_basicSteps
                .IsElementFound("Директор"));
        }


        [Fact]
        public void CreateBranchTest()
        {
            LoginCorrectDataReturnsSuccessAuthTest();
            Thread.Sleep(1000);
            _basicSteps.ClickById("createBranch");
            Thread.Sleep(1000);
            Assert.True(_basicSteps
                .IsElementFound("Добавить центр йоги"));
            _basicSteps.FillTextField("name", "Good Filial");
            _basicSteps.FillTextField("info", "Good Filial 1");
            _basicSteps.FillTextField("address", "Good Filial 1/2");
            _basicSteps.FillTextField("adminId", "Employee");
            _basicSteps.ClickById("send");
            Thread.Sleep(1000);
            Assert.True(_basicSteps
                .IsElementFound("Директор"));
        }

        [Fact]
        public void CheckValidationCreateGroupPageTest()
        {
            LoginCorrectDataReturnsSuccessAuthTest();
            Thread.Sleep(1000);
            _basicSteps.ClickLink("Создать группу");
            Thread.Sleep(1000);
            _basicSteps.GoToUrl("http://localhost:5000/Group/CreateGroup");
            Assert.True(_basicSteps
                .IsElementFound("Добавить новую группу"));
            _basicSteps.FillTextField("Name", String.Empty);
            _basicSteps.ClickById("submit");
            Thread.Sleep(1000);
            Assert.True(_basicSteps
                .IsElementFound("Введите наименование группы"));
        }

        [Fact]
        public void CheckCreateGroupPageTest()
        {
            LoginCorrectDataReturnsSuccessAuthTest();
            Thread.Sleep(1000);
            _basicSteps.ClickLink("Создать группу");
            Thread.Sleep(1000);
            _basicSteps.GoToUrl("http://localhost:5000/Group/CreateGroup");
            Assert.True(_basicSteps
                .IsElementFound("Добавить новую группу"));
            _basicSteps.FillTextField("Name", "Apple");
            _basicSteps.ClickById("submit");
            Thread.Sleep(1000);
            Assert.True(_basicSteps
                .IsElementFound("Добавить новую группу"));
        }

        [Fact]
        public void AddScheduleTest()
        {
            CheckTheСalendarPageTest();
            _basicSteps.ClickButton("Добавить расписание");
            Thread.Sleep(1000);
            Assert.True(_basicSteps
                .IsElementFound("Создать расписание"));
            _basicSteps.FillTextField("selectInput", "Aplle");
            _basicSteps.FillTextField("selectColor", "Красный");
            _basicSteps.FillTextField("timeInputStart", "11:00");
            _basicSteps.FillTextField("timeInputFinish", "12:00");
            _basicSteps.ClickLink("Понедельник");
            _basicSteps.ClickLink("Среда");
            _basicSteps.ClickLink("Пятница");
            _basicSteps.ClickById("submitBtn");
            Thread.Sleep(3000);
            Assert.True(_basicSteps
                .IsElementFound("Октябрь 2020"));
        }

        [Fact]
        public void CheckAddScheduleValidationTest()
        {
            CheckTheСalendarPageTest();
            _basicSteps.ClickButton("Добавить расписание");
            Thread.Sleep(1000);
            Assert.True(_basicSteps
                .IsElementFound("Создать расписание"));
            _basicSteps.FillTextField("selectInput", String.Empty);
            _basicSteps.FillTextField("selectColor", "Красный");
            _basicSteps.FillTextField("timeInputStart", "11:00");
            _basicSteps.FillTextField("timeInputFinish", "12:00");
            _basicSteps.ClickLink("Понедельник");
            _basicSteps.ClickLink("Среда");
            _basicSteps.ClickLink("Пятница");
            _basicSteps.ClickById("submitBtn");
            Thread.Sleep(1000);
            Assert.True(_basicSteps
                .IsElementFound("Необходимо выбрать группу"));
        }


        [Fact]
        public void CheckTheСalendarPageTest()
        {
            LoginCorrectDataReturnsSuccessAuthTest();
            _basicSteps.ClickLink("Календарь");
            _basicSteps.GoToUrl("http://localhost:5000/Schedule?branchId=1");
            Assert.True(_basicSteps
                .IsElementFound("Октябрь 2020"));
        }

        [Fact]
        public void CheckTransactionsPageTest()
        {
            LoginCorrectDataReturnsSuccessAuthTest();
            Thread.Sleep(1000);
            _basicSteps.ClickLink("Касса");
            Thread.Sleep(1000);
            _basicSteps.ClickById("branchId");
            Thread.Sleep(1000);
            Assert.True(_basicSteps
                .IsElementFound("Касса филиала"));
        }


        [Fact]
        public void CheckEditBranchInputTest()
        {
            LoginCorrectDataReturnsSuccessAuthTest();
            Thread.Sleep(1000);
            _basicSteps.ClickLink("Открыть");
            Thread.Sleep(1000);
            _basicSteps.ClickLink("Скрыть");
        }


        [Fact]
        public void EditChiefProfileTest()
        {
            LoginCorrectDataReturnsSuccessAuthTest();
            _basicSteps.ClickById("chief");
            Thread.Sleep(2000);
            _basicSteps.ClickById("/employees/geteditmodalajax");
            Thread.Sleep(1000);
            Assert.True(_basicSteps
                .IsElementFound("Редактирование профиля"));
            _basicSteps.FillTextField("userNameEdit", "dir@gmail.com");
            _basicSteps.FillTextField("emailEdit", "Chief");
            _basicSteps.FillTextField("nameSurnameEdit", "Chief Chief");
            _basicSteps.ClickById("editSaveBtn");
        }

        [Fact]
        public void EditChiefProfileValidationTest()
        {
            LoginCorrectDataReturnsSuccessAuthTest();
            Thread.Sleep(1000);
            _basicSteps.ClickById("chief");
            Thread.Sleep(2000);
            _basicSteps.ClickById("/employees/geteditmodalajax");
            Thread.Sleep(1000);
            Assert.True(_basicSteps
                .IsElementFound("Редактирование профиля"));
            _basicSteps.FillTextField("userNameEdit", String.Empty);
            _basicSteps.FillTextField("emailEdit", String.Empty);
            _basicSteps.FillTextField("nameSurnameEdit", String.Empty);
            _basicSteps.ClickById("editSaveBtn");
            Assert.True(_basicSteps
                .IsElementFound("Введите почту"));
        }

        [Fact]
        public void EditChiefProfilePasswordTest()
        {
            LoginCorrectDataReturnsSuccessAuthTest();
            Thread.Sleep(1000);
            _basicSteps.ClickById("chief");
            Thread.Sleep(2000);
            _basicSteps.ClickById("/employees/getchangepasswordmodalajax");
            Thread.Sleep(1000);
            Assert.True(_basicSteps
                .IsElementFound("Изменение пароля"));
            _basicSteps.FillTextField("currentPassword", "12345678910");
            _basicSteps.FillTextField("newPassword", "mamapapa+123");
            _basicSteps.FillTextField("newPasswordConfirm", "mamapapa+123");
            _basicSteps.ClickById("changePasswordSubmit");
        }

        [Fact]
        public void EditChiefProfilePasswordValidationTest()
        {
            LoginCorrectDataReturnsSuccessAuthTest();
            Thread.Sleep(1000);
            _basicSteps.ClickById("chief");
            Thread.Sleep(2000);
            _basicSteps.ClickById("/employees/getchangepasswordmodalajax");
            Thread.Sleep(1000);
            Assert.True(_basicSteps
                .IsElementFound("Изменение пароля"));
            _basicSteps.FillTextField("currentPassword", "12345678910");
            _basicSteps.FillTextField("newPassword", "mamapapa+12");
            _basicSteps.FillTextField("newPasswordConfirm", "mamapapa+123");
            _basicSteps.ClickById("changePasswordSubmit");
            Assert.True(_basicSteps
                .IsElementFound("Неверный пароль"));
        }

        [Fact]
        public void CreateNewClientTest()
        {
            CheckTheСalendarPageTest();
            Thread.Sleep(1000);
            _basicSteps.ClickLink("Samsung (12:00-13:00) 0");
            Thread.Sleep(1000);
            Assert.True(_basicSteps
                .IsElementFound("Расписание группы"));
            Thread.Sleep(1000);
            Assert.True(_basicSteps
                .IsElementFound("Расписание группы"));
        }
    }
}