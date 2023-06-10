import { Layout, ListaProfessor, AddEditProfessor} from '@/views/professor';

export default {
    path: '/professor',
    component: Layout,
    children: [
        { path: '', component: ListaProfessor },
        { path: 'adicionar', component: AddEditProfessor },
        
    ]
};
