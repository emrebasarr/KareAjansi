using KareAjansi.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KareAjansi.BLL.Repositories
{
    public interface IMankenRepository
    {
        //Listeleme
        List<MankenDTO> GetAllMankenler();

        //Sadece Id'si istenileni getir
        MankenDTO GetMankenById(int id);

        //Ekleme
        void AddManken(MankenDTO manken);

        //Silme
        string DeleteManken(int id);

        //Güncelle
        MankenDTO UpdateManken(MankenDTO manken);

        //Arama
        List<MankenDTO> SearchManken(string value);
    }
}