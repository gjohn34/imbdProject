import React, { Component, useEffect, useState } from 'react';

import './custom.css'

export default function App() {
    const [movies, setMovies] = useState([])
    const [directors, setDirectors] = useState([])

    useEffect(() => {
        fetch("https://localhost:44351/api/Movies")
            .then(response => response.json())
            .then(data => setMovies(data))
        fetch("https://localhost:44351/api/Directors")
            .then(response => response.json())
            .then(data => setDirectors(data))
            
    }, [])
    return (
        <>
            <header class="navbar container-fluid navbar-expand-sm navbar-light bg-warning container-fluid">
                    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                        <span class="navbar-toggler-icon"></span>
                    </button>
                    <div class="collapse navbar-collapse" id="navbarSupportedContent">
                        <nav class="navbar-nav me-auto mb-2 mb-lg-0">
                            <a class="nav-item nav-link active" aria-current="page" href="#">Home</a>
                            <a class="nav-item nav-link active" aria-current="page" href="#">Movies</a>
                            <a class="nav-item nav-link active" aria-current="page" href="#">Directors</a>
                        </nav>
                        <form class="d-flex">
                            <input class="form-control me-2" type="search" placeholder="Search" aria-label="Search"/>
                            <button class="btn btn-outline-dark" type="submit">Search</button>
                        </form>
                    </div>
            </header>

            <main className="container-md">
                <h2>Movies</h2>
                <section id="movies-collection"  class="d-flex flex-wrap justify-content-evenly">
                    {movies && movies.map(movie => (
                        <div className="card m-2">
                            <img src="./placeholder.jpg" className="card-img-top"/>
                            <div className="card-body">
                                <h2 className="text-wrap">{movie.Title}</h2>
                                <p>{movie.ReleaseYear}</p>
                                <p>{movie.Director.FirstName}</p>
                            </div>
                        </div>
                        ))}
                </section>
                <h2>Directors</h2>
                <section id="directors-collection">
                    {directors && directors.map(director => (
                        <div className="card">
                            <h2>{director.FirstName} {director.LastName}</h2>
                        </div>
                    ))}
                </section>
            </main>
        </>
    )
}
