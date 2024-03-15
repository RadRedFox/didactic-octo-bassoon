export interface Movie {
    id: number
    title: string
    ratings?: Rating[]
    actors?: Actor[]
}

export interface Rating {
    id: number
    source: string
    score: number
}

export interface Actor {
    id: number
    firstName: string
    lastName?: string
    movies?: Movie[]
}

export interface SearchResults {
    movies: Movie[]
    actors: Actor[]
}
