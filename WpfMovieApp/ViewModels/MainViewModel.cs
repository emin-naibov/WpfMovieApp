using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Windows;
using WpfMovieApp.Models;
using WpfMovieApp.MVVMtools;

namespace WpfMovieApp.ViewModels
{
    class MainViewModel:ViewModelBase
    {

        private Movies movies;

        public Movies Movies_ { get => movies; set => OnChanged(out movies, value); }


        private string search_movie;

        public string Search_movie { get => search_movie; set => OnChanged(out search_movie, value); }

        private string title;

        public string Title { get => title; set => OnChanged(out title, value); }

        private string year;

        public string Year { get => year; set => OnChanged(out year, value); }

        public void GetMovies()
        {
            Movies_ = new Movies();
            WebClient webClient = new WebClient();
            try
            {
                var json = webClient.DownloadString($"https://www.omdbapi.com/?apikey=8845768d&s={Search_movie}");
                Movies_ = JsonSerializer.Deserialize<Movies>(json);
                MessageBox.Show(Movies_.totalResults);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private Command movie_command;
        public Command Movie_command => movie_command ?? (movie_command = new Command(
            () =>
            {
                MessageBox.Show("hey");
                GetMovies();
            }
            ));

    }
}
