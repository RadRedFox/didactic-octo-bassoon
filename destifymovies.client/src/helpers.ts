import {
    API_BASE_URL,
    API_SECRET
} from './constants'

const buildUrl = (...urlParts: string[]) => urlParts
    .map((part) => part.trim())
    .map((part) => part.length && part[0] === '/' ? part.slice(1) : part)
    .filter((part) => part.trim().length)
    .join('/')

interface IMakeApiRequestOptions {
    method: 'GET' | 'POST' | 'PUT' | 'PATCH' | 'DELETE'
    body?: unknown,
    
}

export const makeApiRequest = (urlParts: string | string[], requestOptions?: IMakeApiRequestOptions, controller = new AbortController()) => {
    const url = buildUrl(API_BASE_URL, ...urlParts)
    const method = requestOptions?.method || 'GET'
    const headers: { [key: string]: string } = {
        'Access-Control-Allow-Origin': '*'
    }
    const signal = controller.signal

    if (method === 'GET') return fetch(url, {
        method,
        headers,
        signal
    })

    headers['Content-Type'] = 'application/json'

    const body = JSON.stringify({
        secretKey: API_SECRET,
        body: requestOptions?.body ? requestOptions.body : {}
    })

    return fetch(url, {
        method,
        headers,
        signal,
        body
    })
}
