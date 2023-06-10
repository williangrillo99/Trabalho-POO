<script setup>
import * as Yup from 'yup';
import { Form, Field } from 'vee-validate';
import { router } from '@/router';
import { useProfessorStore, useAlertStore } from '@/stores';


const professorStore = useProfessorStore();
const alertStore = useAlertStore();


let professor = null;

const schema = Yup.object().shape({
    Nome: Yup.string()
        .required('First Name is required'),
});

async function onSubmit(values){
    try {
        let messagem;
        await professorStore.adicionar(values);  
        messagem = 'Professor Adicionado';
        await router.push('/professor');
        alertStore.success(messagem);
    }
    catch(error){
        alertStore.error(error);
    }
}


</script>

<template>
    <h1>Adicionar Professor</h1>

    <Form @submit="onSubmit" :validation-schema="schema" :initial-values="professor" v-slot="{ errors, isSubmitting }">
            <div class="form-row">
                <div class="form-group col">
                    <label>Nome do Professor</label>
                    <Field name="Nome" type="text" class="form-control" :class="{ 'is-invalid': errors.Nome }" />
                    <div class="invalid-feedback">{{ errors.Nome }}</div>
                </div>
            </div>
    <div class="form-group">
                <button class="btn btn-primary" :disabled="isSubmitting">
                    <span v-show="isSubmitting" class="spinner-border spinner-border-sm mr-1"></span>
                    Adicionar
                </button>
                <router-link to="/professor" class="btn btn-link">Cancelar</router-link>
    </div>
    </Form>

    <template v-if="professor?.loading">
        <div class="text-center m-5">
            <span class="spinner-border spinner-border-lg align-center"></span>
        </div>
    </template>
    <template v-if="professor?.error">
        <div class="text-center m-5">
            <div class="text-danger">Error {{professor.error}}</div>
        </div>
    </template>

</template>
