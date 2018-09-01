using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Encapsular;
using System.Data;

namespace Logica
{
    public class Logi_Buscar
    {
        public Enca_Usuario busca(String buscar)
        {
            
            DUsuario data = new DUsuario();
            DataTable datos = new DataTable();
            Enca_Usuario busqueda = new Enca_Usuario();

            datos = data.busquedaUser(buscar);

            return busqueda;

        }
    }
}
