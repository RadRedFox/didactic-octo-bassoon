import { SearchResults } from './types'

export const runSearch = async (term: string, controller = new AbortController()) => {
    try {
        const response = await fetch(`https://localhost:32768/api/v1/Search/${term}`, {
            method: 'GET',
            headers: {
                'Access-Control-Allow-Origin': '*'
            },
            signal: controller.signal
        })
        const data = await response.json()

        return data as SearchResults
    } catch (error) {
        console.error('Problem retrieving search results', { error });
        return {} as SearchResults
    }
}
