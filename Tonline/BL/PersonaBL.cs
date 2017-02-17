using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
   public class PersonaBL:Repositorio<persona>
    {
        public static persona ObtenerPersona(string usuario) {

            using ( var db = new BDEntities() ) {
                db.Configuration.ProxyCreationEnabled = false;
                db.Configuration.LazyLoadingEnabled = false;
                db.Configuration.ValidateOnSaveEnabled = false;

                int personaid = db.usuario.First(x => x.Nombre == usuario).PersonaId;
                return db.persona.Find(personaid);
            }
        }

    }
}
