import { Actor } from './types'
import { makeApiRequest } from '../helpers'

const ACTOR_API_BASE = 'v1/Actors'

export const getActors = async (controller = new AbortController()) => {
    try {
        const response = await makeApiRequest([ACTOR_API_BASE], { method: 'GET' }, controller)
        const data = await response.json()

        return data as Actor[]
    } catch (error) {
        console.error('Problem retrieving actors data', { error });
        return [] as Actor[]
    }
}

export const getActor = async (id: number, controller = new AbortController()) => {
    try {
        const response = await makeApiRequest([ACTOR_API_BASE, String(id)], { method: 'GET' }, controller)
        const data = await response.json()

        return data as Actor
    } catch (error) {
        console.error('Problem retrieving actor data', { error });
        return null
    }
}

interface IAddActorBody {
    firstName: string
    lastName: string
}

export const addActor = async (body: IAddActorBody, controller = new AbortController()) => {
    try {
        const response = await makeApiRequest([ACTOR_API_BASE, 'Add'], { method: 'POST', body }, controller)
        const data = await response.json()

        return data as Actor
    } catch (error) {
        console.error('Problem saving movie', { error })

        return null
    }
}
