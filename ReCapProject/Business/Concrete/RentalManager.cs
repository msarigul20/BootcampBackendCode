using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Transaction;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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

        /*
         *  To Prevent null return date problem (used "rental.ReturnDate!=null" to check):
         *      If ReturnDate is null to add first time, the car can rent as free or 
         *      it seems that already rented but it is not in real.
         *      
         *  At the end: when looking the detail, we need to see return date (NOT NULL) 
         *      immediately after adding process.
         */

        //  Used resultToCheckRented to prevent to rent car that is already rented.

        public IResult Add(Rental rental)
        {         
            if (rental.ReturnDate!=null)
            {
                return new ErrorResult(Messages.RentalReturnDateNullCheck);
            }

            var resultToCheckRented = _rentalDal.GetRentalDetails(
                    (r => r.CarId == rental.CarId && r.ReturnDate==null)
                );
            
            if (resultToCheckRented.Count > 0)
            {
                return new ErrorResult(Messages.RentalAlreadyRented);
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

        //  Used "updatedRental.ReturnDate != null":
        //      to prevent to complete rental that is already completed.

        [TransactionScopeAspect]
        public IResult CompleteRentalById(int id)
        {
            var updatedRental = _rentalDal.GetAll(r => r.Id == id).SingleOrDefault();
            
            if (updatedRental.ReturnDate != null)
            {
                return new ErrorResult(Messages.RentalAlreadyCompleted);
            }

            updatedRental.ReturnDate = DateTime.Now;
            _rentalDal.Update(updatedRental);

            return new SuccessResult(Messages.RentalCompleted);
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            _rentalDal.GetRentalDetails();
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
        }
    }
}