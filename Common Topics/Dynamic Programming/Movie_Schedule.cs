using System;
using System.Collections.Generic;

namespace Common_Topics
{
    /*
        Given a group of movies and their start time, assuming that are 1 hour long, 
        Returns all possible movie schedules (no time conflicts).

        Complexity: O(n*k) where n - a number of possible times, k - a number of movies.
     */
    public class Movie_Schedule
    {
        protected List<Movie> movies = new List<Movie>();
        protected Dictionary<int, List<Movie>> movieTimings = new Dictionary<int, List<Movie>>();
        protected HashSet<Movie> movieUniqueList = new HashSet<Movie>();
        protected int[] times;

        public Movie_Schedule(List<Movie> movies)
        {
            this.movies = movies;

            foreach (Movie movie in movies)
            {
                foreach (int time in movie.Times)
                {
                    if (!movieTimings.ContainsKey(time))
                    {
                        movieTimings.Add(time, new List<Movie>());
                    }
                    
                    movieTimings[time].Add(movie);
                }

                movieUniqueList.Add(movie);
            }

            times = new int[movieTimings.Count];
            movieTimings.Keys.CopyTo(times, 0);
        }

        public List<LinkedList<Movie>> CreatePossibleSchedules()
        {
            List<LinkedList<Movie>> schedules = new List<LinkedList<Movie>>();
            CreatePossibleSchedules(schedules, new LinkedList<Movie>(), movieUniqueList, 0);

            return schedules;
        }

        protected void CreatePossibleSchedules(List<LinkedList<Movie>> schedules, LinkedList<Movie> currentSchedule, HashSet<Movie> movieUniqueList, int timeCoursor)
        {
            if (times.Length > timeCoursor)
            {
                foreach (Movie movie in movieTimings[times[timeCoursor]])
                {
                    if (movieUniqueList.Contains(movie))
                    {
                        LinkedList<Movie> tmpSchedule = new LinkedList<Movie>(currentSchedule);
                        tmpSchedule.AddLast(movie);
                        HashSet<Movie> tmpMovieUniqueList = new HashSet<Movie>(movieUniqueList);
                        tmpMovieUniqueList.Remove(movie);
                        CreatePossibleSchedules(schedules, tmpSchedule, tmpMovieUniqueList, timeCoursor + 1);
                    }
                }
            } else if (movieUniqueList.Count == 0)
            {
                schedules.Add(currentSchedule);
            }
        }
    }

    public class Movie
    {
        protected string name;
        protected int[] times;

        public Movie(string name, int[] times)
        {
            this.name = name;
            this.times = times;
        }

        public string Name
        {
            get
            {
                return name;
            }
        }

        public int[] Times
        {
            get
            {
                return times;
            }
        }
    }
}