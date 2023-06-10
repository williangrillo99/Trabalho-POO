<script setup>
import { storeToRefs } from 'pinia';
import { useTurmaStore } from '@/stores';


const turmasStore = useTurmaStore();
const {turmas} = storeToRefs(turmasStore);

turmasStore.getAll();

</script>

<template>
    <h1>Turmas</h1>
    <router-link to="#" class="btn btn-sm btn-success mb-2">Adicionar Turma</router-link>

    <table class="table table-striped">
        <thead>
            <tr>
                <th style="width: 30%">Turma</th>
                <th style="width: 30%">Professor</th>
                <th style="width: 10%"></th>
            </tr>
            <tbody>
                <template v-if="turmas.length">
                    <tr v-for="turma in turmas">
                        <td>
                            {{turma.nome }}
                        </td>
                    </tr>
                </template>
            </tbody>

        </thead>
    </table>

</template>
