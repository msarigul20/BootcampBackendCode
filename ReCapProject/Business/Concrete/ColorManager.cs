using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;


        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public void Add(Color color)
        {
            _colorDal.Add(color);
            Console.WriteLine($"The color that is id of {color.ColorId} has been added succesfully.");
        }

        public void Delete(Color color)
        {
            _colorDal.Delete(color);
            Console.WriteLine($"The color that is id of {color.ColorId} has been deleted succesfully.");
        }

        public List<Color> GetAll()
        {
            return _colorDal.GetAll();
        }

        public Color GetColorById(int id)
        {
            return _colorDal.Get(c => c.ColorId == id);
        }

        public void Update(Color color)
        {
            _colorDal.Update(color);
            Console.WriteLine($"The color that is id of {color.ColorId} has been updated succesfully.");
        }
    }
}
