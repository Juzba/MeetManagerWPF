using MeetManagerWPF.ViewModel;


namespace MeetManagerWPF.Tests
{

    [TestFixture]
    public class SampleTests(LoginViewModel loginViewModel)
    {
        private readonly LoginViewModel _loginViewModel = loginViewModel;


        [Test]
        public void Test1()
        {
            

            int a = 5;
            int b = 8;

            int result = a + b;

            // Fix: Replace Assert.AreEqual with Assert.That and use the appropriate constraint
            Assert.That(result, Is.EqualTo(7)); // Očekávaná hodnota je 7 (5 + 2), ne 8
        }
    }
}

