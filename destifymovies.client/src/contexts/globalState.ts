import { createContext } from 'react'

import {
    type Actor,
    type Movie,
    type Rating
} from '../lib'

interface IGlobalState {
    movies: Movie[]
    setMovies: (movies: Movie[], overwrite?: boolean) => void
    actors: Actor[]
    setActors: (actors: Actor[]) => void
    ratings: Rating[]
    setRatings: (ratings: Rating[]) => void
    activeMovie: number | null
    setActiveMovie: (id: number) => void
    activeActor: number | null
    setActiveActor: (id: number) => void
}

export const GlobalStateContext = createContext<IGlobalState>({
    movies: [],
    setMovies: () => { },
    actors: [],
    setActors: () => { },
    ratings: [],
    setRatings: () => { },
    activeMovie: null,
    setActiveMovie: () => { },
    activeActor: null,
    setActiveActor: () => { }
})

const GlobalState = GlobalStateContext.Provider;

export default GlobalState

