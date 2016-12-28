using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLager.Repositories
{
    public class PictureRepository
    {
        public static void UploadPicture(string användarnamn, string pic)
        {
            using (var db= new DataBasEntities())
            {
                Änder bild = db.Änder.FirstOrDefault(x => x.Användarnamn == användarnamn);
                bild.Profilbild = pic;
                db.SaveChanges();
            }
        }
    }
}
