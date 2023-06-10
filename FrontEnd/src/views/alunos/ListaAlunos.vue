<script setup>
import { storeToRefs } from 'pinia';

import { useAlunosStore } from '@/stores';

const alunosStore = useAlunosStore();
const { alunos } = storeToRefs(alunosStore);

alunosStore.getAll();
</script>

<template>
    <h1 style="color: red
    ">Alunos</h1>
    <router-link to="/users/add" class="btn btn-sm btn-success mb-2">Adicionar Aluno</router-link>

    <table class="table table-striped">
        <thead>
            <tr>
                <th style="width: 30%">Aluno</th>
                <th style="width: 10%"></th>
            </tr>
        </thead>
        <tbody>
            <template v-if="alunos.length">
                <tr v-for="aluno in alunos" :key="aluno.id">
                    <td>{{ aluno.usuario.nome }}</td>
                    <td style="white-space: nowrap">
                        <router-link :to="`/users/edit/${aluno.id}`" class="btn btn-sm btn-primary mr-1">Edit</router-link>
                       <button class="btn btn-sm btn-danger btn-delete-user" :disabled="aluno.isDeleting">
                            <span v-if="aluno.isDeleting" class="spinner-border spinner-border-sm"></span>
                            <span v-else>Delete</span>  
                        </button> 
                    </td>
                </tr>
            </template>
            <tr v-if="alunos.loading">
                <td colspan="4" class="text-center">
                    <span class="spinner-border spinner-border-lg align-center"></span>
                </td>
            </tr>
            <tr v-if="alunos.error">
                <td colspan="4">
                    <div class="text-danger">Error loading users: {{alunos.error}}</div>
                </td>
            </tr>            
        </tbody>
    </table> 
</template>
