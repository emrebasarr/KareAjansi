using KareAjansi.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KareAjansi.BLL.Repositories
{
    public interface IOrganizasyonMankenRepository
    {
        public List<OrganizasyonMankenDTO> GetOrganizasyonMankenDetails();
        public void AddOrganizasyonManken(OrganizasyonMankenDTO organizasyonMankenDTO);
        string DeleteOrganizasyonManken(int id);
        List<OrganizasyonMankenDTO> SearchOrganizasyonManken(string value);
    }
}