import axios from "axios";
import type {
    Pessoa
} from '../types/Pessoa.ts';

const api = axios.create({
    baseURL: 'http://localhost:5183/v1'
})


/**
 * Serviço para gerenciar Pessoas
 */
export const pessoasService = {
    listar: async (): Promise<Pessoa[]> => {
        const response = await api.get<Pessoa[]>('/pessoas/listar-pessoas');
        return response.data;
    },

    obterPorId: async (id: number): Promise<Pessoa> => {
        const response = await api.get<Pessoa>(`/pessoas/obter-pessoa/${id}`);
        return response.data;
    },

    deletar: async (id: number): Promise<void> => {
        await api.delete(`/pessoas/deletar/${id}`);
    },
};

export default api;