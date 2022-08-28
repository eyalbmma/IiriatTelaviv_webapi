﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainIriatTelaviv.Entities
{
	[Table("Users")]
	public class Users
	{
		[Key]
		public int id { get; set; }
		
		public string? Email { get; set; }
		public string? Password { get; set; }
		


	}
}
