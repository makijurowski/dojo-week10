using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Options;
using MovieAPI.Properties;
using MySql.Data.MySqlClient;

namespace MovieAPI
{
    public class Movie
    {
        string movie_title { get; set; }
        string movie_rating { get; set; }
        string movie_release_date { get; set; } 
    }
}