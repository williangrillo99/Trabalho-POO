<script setup>
import { storeToRefs } from 'pinia';
import { useProfessorStore } from '@/stores';

const professorStore = useProfessorStore();
const { professores } = storeToRefs(professorStore);

professorStore.getAll();

</script>

<template>
    <h1>Professores</h1>
    <router-link to="/professor/adicionar" class="btn btn-sm btn-success mb-2">Adicionar Professor</router-link>

    <table class="table table-striped">
        <thead>
            <tr>
                <th style="width: 30%">Professor</th>
                <th style="width: 30%">Turma</th>
                <th style="width: 10%"></th>
            </tr>
        </thead>
        <tbody>
            <template v-if="professores.length"> 
                <tr v-for="professor in professores">
                <td>{{ professor.nome }}</td>
                <td v-if="professor.turmas">{{ professor.turmas.nome }}</td>
                <td v-if="!professor.turmas">Professor sem turma</td>
                <td style="white-space: nowrap">
                    <router-link :to="`/users/edit/${professor.id}`" class="btn btn-sm btn-primary mr-1">Edit</router-link>
                    <button @click="usersStore.delete(professor.id)" class="btn btn-sm btn-danger btn-delete-professor"
                        :disabled="professor.isDeleting">
                        <span v-if="professor.isDeleting" class="spinner-border spinner-border-sm"></span>
                        <span v-else>Delete</span>
                    </button>
                </td>
                </tr>
            </template>
            <tr v-if="professores.loading">
                <td colspan="4" class="text-center">
                    <span class="spinner-border spinner-border-lg align-center"></span>
                </td>
            </tr>
        </tbody>
    </table>
</template>
