<script setup>
import { storeToRefs } from 'pinia';

import { useAuthStore } from '@/stores';

const authStore = useAuthStore();
const { user } = storeToRefs(authStore);
</script>

<template>
    <div v-if="user.tipoUsuarioEnum == 1">
        <h1>Olá Estudante {{user.nome}}!</h1>
        <p>You're logged in with Vue 3 + Pinia & JWT!!</p>
        <p><router-link to="/users">Manage Users</router-link></p>
    </div>
    <div v-if="user.tipoUsuarioEnum == 2">
        <h1>Olá Professor   {{user.nome}}!</h1>
        <p>You're logged in with Vue 3 + Pinia & JWT!!</p>
        <p><router-link to="/users">Manage Users</router-link></p>
    </div>
    <div v-if="user.tipoUsuarioEnum == 3">
        <h1>Olá Admin {{user.nome}}!</h1>
        <p>You're logged in with Vue 3 + Pinia & JWT!!</p>
        <p><router-link to="/users">Manage Users</router-link></p>
    </div>
</template>
