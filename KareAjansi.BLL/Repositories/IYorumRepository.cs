using KareAjansi.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KareAjansi.BLL.Repositories
{
    public interface IYorumRepository
    {
        YorumDTO GetYorumlarByMankenId(int mankenId);
        void AddYorum(YorumDTO yorum);
        string DeleteYorum(int yorumId);
        YorumDTO UpdateYorum(YorumDTO yorum);
    }
}