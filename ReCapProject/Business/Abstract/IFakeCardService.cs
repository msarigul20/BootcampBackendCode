using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IFakeCardService
    {
        IResult Add(FakeCard fakeCard);
        IResult Update(FakeCard fakeCard);
        IResult Delete(FakeCard fakeCard);
        IResult DoesCardExist(FakeCard fakeCard);
        IDataResult<List<FakeCard>> GetByCardNumber(string cardNumber);
        IDataResult<FakeCard> GetById(int cardId);
        IDataResult<List<FakeCard>> GetAll();
    }
}
