using KareAjansi.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KareAjansi.BLL.Repositories
{
    public interface IOrganizasyonRepository
    {
        //Listeleme
        List<OrganizasyonDTO> GetAllOrganizasyonlar();

        //Ekleme
        void AddOrganizasyon(OrganizasyonDTO organizasyon);

        OrganizasyonDTO GetOrganizasyonById(int id);

        string DeleteOrganizasyon(int id);

        OrganizasyonDTO UpdateOrganizasyon(OrganizasyonDTO updatedOrganizasyon);

        //Arama
        List<OrganizasyonDTO> SearchOrganizasyon(string value);
    }
}