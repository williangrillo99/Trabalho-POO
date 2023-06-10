import { defineStore } from 'pinia';
import { fetchWrapper } from '../helpers';

const baseUrl = `${import.meta.env.VITE_API_URL}/Turmas`;

export const useTurmaStore = defineStore({
    id: 'turmas',
    state: () => ({
        turma: {},
        turmas: {}
    }),

    actions: {
        async getAll(){
            this.turmas = {loading : true};
            try{
                this.turmas = await fetchWrapper.get(`${baseUrl}/Listar`);
                console.log(this.turmas)
            }
            catch(error){
                return false;
            }
        },

        async adicionar(tumar){
            console.log("adicionando turma", professor)
            await fetchWrapper.post(`${baseUrl}/Adicionar`, professor);
        }
    }

})