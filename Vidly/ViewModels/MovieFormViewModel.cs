﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {

        public MovieFormViewModel()
        {
            Id = 0;
        }

        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleasedDate = movie.ReleasedDate;
            NumberInStock = movie.NumberInStock;
            GenreId = movie.GenreId;
        }


        public IEnumerable<Genre> Genres { get; set;}

        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public byte? GenreId { get; set; }


        [Display(Name = "Release Date")]
        [Required]
        public DateTime? ReleasedDate { get; set; }

    

        [Display(Name = "Number in Stock")]
        [Range(1,20)]
        [Required]
        public byte? NumberInStock { get; set; }

        public string Title
        {
            get
            {
               return (Id != 0)? "Edit Movie" : "New Movie";
            }
        }
    }
}