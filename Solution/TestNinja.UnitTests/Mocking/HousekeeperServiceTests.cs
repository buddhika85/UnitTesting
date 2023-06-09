﻿using Moq;
using TestNinja.Mocking;
using IEmailSender = TestNinja.Mocking.IEmailSender;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class HousekeeperServiceTests
    {
        private HousekeeperService _housekeeperService = null!;
        private Mock<IUnitOfWork> _unitOfWorkMock = null!;
        private Mock<IStatementGenerator> _statementGeneratorMock = null!;
        private Mock<IEmailSender> _emailSenderMock = null!;
        private Mock<IXtraMessageBox> _messageBoxMock = null!;


        private readonly List<Housekeeper> _houseKeepers = new()
        {
            new() { Email = "a@a.com", Oid = 1, FullName = "a", StatementEmailBody = "Statement Email Body" },
        };

        private readonly string _statementFileName = "statementFilename.pdf";

        private readonly DateTime _testDateTime = DateTime.Today;


        [SetUp]
        public void SetUp()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _unitOfWorkMock.Setup(x => x.Query<Housekeeper>())
                .Returns(_houseKeepers.AsQueryable);

            _statementGeneratorMock = new Mock<IStatementGenerator>();
            _statementGeneratorMock.Setup(x => x.SaveStatement(_houseKeepers.First().Oid,
                _houseKeepers.First().FullName,
                _testDateTime)).Returns(_statementFileName);

            _emailSenderMock = new Mock<IEmailSender>();
            _messageBoxMock = new Mock<IXtraMessageBox>();
        }

        [Test]
        public void SendStatementEmails_WhenCalled_SaveStatementMethodInteracted()
        {
            // arrange
            _housekeeperService = new HousekeeperService(_unitOfWorkMock.Object,
                _statementGeneratorMock.Object, _emailSenderMock.Object, _messageBoxMock.Object);

            // act
            _housekeeperService.SendStatementEmails(_testDateTime);

            // assert
            _statementGeneratorMock.Verify(x =>
                x.SaveStatement(_houseKeepers.First().Oid, _houseKeepers.First().FullName,
                    _testDateTime));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void SendStatementEmails_WhenEmailNullOrEmptyOrWhiteSpace_SaveStatementMethodNotInteracted(string? email)
        {
            // arrange
            _houseKeepers.First().Email = email;
            _housekeeperService = new HousekeeperService(_unitOfWorkMock.Object,
                _statementGeneratorMock.Object, _emailSenderMock.Object, _messageBoxMock.Object);

            // act
            _housekeeperService.SendStatementEmails(_testDateTime);

            // assert
            _statementGeneratorMock.Verify(x =>
                x.SaveStatement(_houseKeepers.First().Oid, _houseKeepers.First().FullName,
                    _testDateTime), Times.Never);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void SendStatementEmails_WhenFileNameNullOrEmptyOrWhiteSpace_EmailFileMethodInteracted(string? fileName)
        {
            // arrange
            _statementGeneratorMock.Setup(x => x.SaveStatement(It.IsAny<int>(),
                It.IsAny<string>(),
                It.IsAny<DateTime>())).Returns(fileName);
            _housekeeperService = new HousekeeperService(_unitOfWorkMock.Object,
                _statementGeneratorMock.Object, _emailSenderMock.Object, _messageBoxMock.Object);

            // act
            _housekeeperService.SendStatementEmails(_testDateTime);

            // assert
            _emailSenderMock.Verify(x => x.EmailFile(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>()),
                Times.Never);

        }


        [Test]
        public void SendStatementEmails_WhenCalled_EmailFileMethodInteracted()
        {
            // arrange
            var fileName = $"Sandpiper Statement {_testDateTime:yyyy-MM} {_houseKeepers.First().FullName}";
            _housekeeperService = new HousekeeperService(_unitOfWorkMock.Object,
                _statementGeneratorMock.Object, _emailSenderMock.Object, _messageBoxMock.Object);

            // act
            _housekeeperService.SendStatementEmails(_testDateTime);

            // assert
            _emailSenderMock.Verify(x => x.EmailFile(_houseKeepers.First().Email,
                _houseKeepers.First().StatementEmailBody,
                _statementFileName,
                fileName));

        }

        [Test]
        public void SendStatementEmails_WhenExceptionThrown_MessageBoxShown()
        {
            // arrange
            _statementGeneratorMock.Setup(x => x.SaveStatement(It.IsAny<int>(),
                It.IsAny<string>(),
                It.IsAny<DateTime>())).Returns(_statementFileName);
            _emailSenderMock.Setup(x => x.EmailFile(It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>())).Throws<Exception>();
            _housekeeperService = new HousekeeperService(_unitOfWorkMock.Object,
                _statementGeneratorMock.Object, _emailSenderMock.Object, _messageBoxMock.Object);

            // act
            _housekeeperService.SendStatementEmails(It.IsAny<DateTime>());

            // assert
            _messageBoxMock.Verify(x => x.Show(It.IsAny<string>(), It.IsAny<string>(), MessageBoxButtons.OK));
        }
    }
}
