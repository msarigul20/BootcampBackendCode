using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;


namespace Business.Concrete
{
    public class FakeCardManager : IFakeCardService
    {
        private IFakeCardDal _fakeCarDal;

        public FakeCardManager(IFakeCardDal fakeCardDal)
        {
            _fakeCarDal = fakeCardDal;
        }

        public IResult Add(FakeCard fakeCard)
        {
            _fakeCarDal.Add(fakeCard);
            return new SuccessResult();

        }

        public IResult Delete(FakeCard fakeCard)
        {
            _fakeCarDal.Delete(fakeCard);
            return new SuccessResult();
        }

        public IResult DoesCardExist(FakeCard fakeCard)
        {
            var result = _fakeCarDal.Get(
                c => c.NameOnTheCard.ToLower() == fakeCard.NameOnTheCard.ToLower() &&
                c.CardNumber == fakeCard.CardNumber &&
                c.ExpirationDate == fakeCard.ExpirationDate &&
                c.CardCvv == fakeCard.CardCvv
                );
            if (result == null)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }

        public IDataResult<List<FakeCard>> GetAll()
        {
            return new SuccessDataResult<List<FakeCard>>(_fakeCarDal.GetAll());
        }

        public IDataResult<List<FakeCard>> GetByCardNumber(string cardNumber)
        {
            return new SuccessDataResult<List<FakeCard>>(_fakeCarDal.GetAll(c => c.CardNumber == cardNumber));
        }

        public IDataResult<FakeCard> GetById(int cardId)
        {
            return new SuccessDataResult<FakeCard>(_fakeCarDal.Get(c => c.Id == cardId));
        }

        public IResult Update(FakeCard fakeCard)
        {
            _fakeCarDal.Update(fakeCard);
            return new SuccessResult();
        }
    }
}
