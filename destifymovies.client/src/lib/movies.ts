import { Movie } from './types'
import { makeApiRequest } from '../helpers'

const MOVIE_API_BASE = 'v1/Movies'

export const getMovies = async (controller = new AbortController()) => {
    try {
        const response = await makeApiRequest([MOVIE_API_BASE], { method: 'GET' }, controller)
        const data = await response.json()

        return data as Movie[]
    } catch (error) {
        console.error('Problem retrieving movie data', { error })

        return [] as Movie[]
    }
}

export const getMovie = async (id: number, controller = new AbortController()) => {
    try {
        const response = await makeApiRequest([MOVIE_API_BASE, String(id)], { method: 'GET' }, controller)
        const data = await response.json()

        return data as Movie
    } catch (error) {
        console.error('Problem retrieving movie data', { error })

        return null
    }
}

interface IAddMovieBody {
    title: string
}

export const addMovie = async (body: IAddMovieBody, controller = new AbortController()) => {
    try {
        const response = await makeApiRequest([MOVIE_API_BASE, 'Add'], { method: 'POST', body }, controller)
        const data = await response.json()

        return data as Movie
    } catch (error) {
        console.error('Problem saving movie', { error })

        return null
    }
}

export const removeMovie = async (id: number, controller = new AbortController()) => {
    try {
        await makeApiRequest([MOVIE_API_BASE, 'delete'], { method: 'DELETE', body: { id } }, controller)

        return
    } catch (error) {
        console.error('Problem deleting movie', { error })

        return
    }
}
