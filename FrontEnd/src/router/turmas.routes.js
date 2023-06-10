import { Layout, ListaTurmas } from '../views/turmas';

export default {
    path: '/turmas',
    component: Layout,
    children: [
        { path: '', component: ListaTurmas },

    ]
};
