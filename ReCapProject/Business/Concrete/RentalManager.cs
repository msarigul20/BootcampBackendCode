using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            //Eğer parametreden gelen rental ReturnDate 'i null olmazsa, bedava kiralamış gibi olur.
            //RentalDetail'den null görmediğimiz için o arabayı bizde sanarız.
            if (rental.ReturnDate!=null)
            {
                return new ErrorResult("The car must have return date for first adding.");
            }
            var result = _rentalDal.GetRentalDetails((r => r.CarId == rental.CarId && r.ReturnDate==null));
            if (result.Count > 0)
            {
                return new ErrorResult("The car already rented.");
            }

            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);


        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<Rental> GetRentalById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == id));
        }

        public IResult CompleteRentalByCarId(int id)
        {
            var result = _rentalDal.GetAll(r => r.CarId == id);
            var updatedRental = result.SingleOrDefault();
            if (updatedRental.ReturnDate != null)
            {
                return new ErrorResult("Rental has already return date!");
            }
            updatedRental.ReturnDate = DateTime.Now;
            _rentalDal.Update(updatedRental);
            return new SuccessResult($"Rental ıd number {updatedRental.Id} was updated.");
        }

    }
}
