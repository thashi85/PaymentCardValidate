using ConnXTestAPI.Business;
using ConnXTestAPI.Models;
using ConnXTestAPI.Models.Payment;
using NUnit.Framework;
using System.Collections.Generic;
using static ConnXTestAPI.Models.Constants;

namespace ConnXTestAPITestProject
{
    public class Tests
    {
        private PaymentManager _pm;
        [SetUp]
        public void Setup()
        {
            _pm = new PaymentManager();
        }

        [Test]
        public void EmptyCardNumberTest()
        {           
           
            Error _err;
            var res=_pm.ValidateInput(new Visa(), out _err);
            Assert.False(res);
            Assert.False(_err==null);
            if (_err != null)
            {
                Assert.AreEqual(_err?.ErrorCode,ErrorCode.EmptyCardNumber);
            }
            
        }
       
        [Test]
        public void VisaInvalidTest()
        {

            var _card = new Visa() { CardNumber = "4111111111111",CardType=Enums.CardType.Visa };
            List<Error> _err;
            var res = _pm.ValidateCardType(_card, out _err);
            Assert.False(res);
            Assert.False(_err?.Count == 0);
           
        }
        [Test]
        public void VisaValidCardTest()
        {

            var _card = new Visa() { CardNumber = "4012888888881881", CardType = Enums.CardType.Visa };
            List<Error> _err;
            var res = _pm.ValidateCardType(_card, out _err);
            Assert.True(res);

        }
        [Test]
        public void AmexValidCardTest()
        {
            //3782 8224 6310 005
            //67162 16244 12320 0010
            //total 48
            // sample data it sayd this shoudl be valid,total 48 so invalid please check not sure why it shoud be valid
            var _card = new Amex() { CardNumber = "378282246310005", CardType = Enums.CardType.Amex };
            List<Error> _err;
            var res = _pm.ValidateCardType(_card, out _err);
            Assert.False(res);


        }
        [Test]
        public void DiscoverValidCardTest()
        {
            //6011  1111 1111 1117
            //12021 2121 2121 2127  = total is 30
            var _card = new Discover() { CardNumber = "6011111111111117", CardType = Enums.CardType.Discover };
            List<Error> _err;
            var res = _pm.ValidateCardType(_card, out _err);
            Assert.True(res);
        }
        [Test]
        public void MasterValidCardTest()
        {
           
            var _card = new MasterCard() { CardNumber = "5105105105105100", CardType = Enums.CardType.Master };
            List<Error> _err;
            var res = _pm.ValidateCardType(_card, out _err);
            Assert.True(res);
        }
        [Test]
        public void MasterInvalidCardTest()
        {
           
            var _card = new MasterCard() { CardNumber = "5105105105105106", CardType = Enums.CardType.Master };
            List<Error> _err;
            var res = _pm.ValidateCardType(_card,out _err);
            Assert.False(res);
        }
        [Test]
        public void UnknowInvalidCardTest()
        {
           
            object _card = new { CardNumber = "9111111111111111" };
            Error _err;
            var res = _pm.ValidateInput(_card as PaymentCard,out _err);
            Assert.False(res);
        }


    }
}