using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.cont
{
	public class appuser:IdentityUser<int>
	{
        public string NameUsername { get; set; }

		public string İmageUrl { get; set; }

        public int confirmcode { get; set; }



    }
}
