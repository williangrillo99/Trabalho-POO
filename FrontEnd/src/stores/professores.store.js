import { defineStore } from 'pinia';
import { fetchWrapper } from '@/helpers';

const baseUrl = `${import.meta.env.VITE_API_URL}/Professor`;

export const useProfessorStore = defineStore({
    id: 'professores',
    state: () => ({
    professores: {},  
    professor: {},  
    }),
    actions : {
        async getAll(){
            console.log(this.professores);
            this.professores = {loading: true};
            try{
                this.professores = await fetchWrapper.get(`${baseUrl}/Listar`); 
                console.log(this.professores);
            }
            catch (error){
                return false;
            }
        },
        async adicionar(professor){

            console.log("adicionando professor", professor)
            await fetchWrapper.post(`${baseUrl}/Adicionar`, professor);

        }
    }
})