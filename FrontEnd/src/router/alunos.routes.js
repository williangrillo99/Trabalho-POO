import { Layout, ListarAlunos } from '../views/alunos';

export default {
    path: '/alunos',
    component: Layout,
    children: [
        { path: '', component: ListarAlunos },

    ]
};
