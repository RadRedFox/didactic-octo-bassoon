import { createContext } from 'react'

export interface IModalContext {
    movieModal: [movieModalOpen: boolean, setMovieModalOpen: (state: boolean) => void]
    actorModal: [actorModalOpen: boolean, setActorModalOpen: (state: boolean) => void]
    ratingModal: [ratingModalOpen: boolean, setRatingModalOpen: (state: boolean) => void]
}

export const ModalContextContext = createContext<IModalContext>({
    movieModal: [false, () => { }],
    actorModal: [false, () => { }],
    ratingModal: [false, () => { }]
})

const ModalContext = ModalContextContext.Provider;

export default ModalContext

