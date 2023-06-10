import { defineStore } from 'pinia';
import { fetchWrapper } from '@/helpers';

const baseUrl = `${import.meta.env.VITE_API_URL}/Alunos`;

export const useAlunosStore = defineStore({
    id: 'aluno',

    state: () => ({
        alunos: {},
    }),
    actions : {
        async getAll(){
            
             this.alunos = {location: true};
             try{
                 this.alunos = await fetchWrapper.get(`${baseUrl}/ListarAlunos`); 
             }
             catch (error){
                 return false;
             }
            
        }
    }
})