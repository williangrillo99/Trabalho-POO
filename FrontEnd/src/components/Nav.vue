<script setup>
import { useAuthStore } from '@/stores';

const authStore = useAuthStore();
</script>

<template>
    <nav v-show="authStore.user" class="navbar navbar-expand navbar-dark bg-dark">
        <div class="navbar-nav">
            <router-link to="/" class="nav-item nav-link">Home</router-link>
            <router-link to="/usuarios" class="nav-item nav-link">Usuarios</router-link>
            <router-link to="/professor" class="nav-item nav-link">Professores</router-link>
            <router-link to="/turmas" class="nav-item nav-link">Turmas</router-link>
            <router-link to="/alunos" class="nav-item nav-link">Alunos</router-link>
            <button @click="authStore.logout()" class="btn btn-link nav-item nav-link">Logout</button>
        </div>
    </nav>
</template>