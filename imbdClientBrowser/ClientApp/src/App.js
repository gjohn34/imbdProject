import React, { Component, useEffect, useState } from 'react';
import { Switch, Route, Link } from 'react-router-dom';

import Layout from './components/Layout'
import FlexCollection, { Card } from './components/FlexContainer'

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
            <Layout>
                <Switch>
                    <Route exact path="/">
                        <h2>Movies</h2>
                        <FlexCollection>
                            {movies && movies.map(movie => (
                                <Card key={movie.Id}>
                                    <h2 className="text-wrap">{movie.Title}</h2>
                                    <p>{movie.ReleaseYear}</p>
                                    <p>{movie.Director.FirstName}</p>
                                    <Link to={`/movies/${movie.Id}`} className="align-self-end btn btn-primary">Details</Link>
                                </Card>
                            ))}
                        </FlexCollection>
                        <h2>Directors</h2>
                        <FlexCollection>
                            {directors && directors.map(director => (
                                <Card key={director.Id}>
                                    <h2 className="text-wrap">{director.FirstName} {director.LastName}</h2>
                                    <p>{director.Bio}</p>
                                    <Link to={`/movies/${director.Id}`} className="align-self-end btn btn-primary">Details</Link>
                                </Card>
                            ))}
                        </FlexCollection>
                    </Route>
                    <Route exact path="/movies">
                        <h2>All movies</h2>
                    </Route>
                    <Route exact path="/movies/:id">
                        <h2>Movie Id</h2>
                    </Route>
                    <Route exact path="/directors">
                        <h2>All Directors</h2>
                    </Route>
                    <Route exact path="/directors/:id">
                        <h2>Director Id</h2>
                    </Route>
                </Switch>


            </Layout>
        </>
    )
}
