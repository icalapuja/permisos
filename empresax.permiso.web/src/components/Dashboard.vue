<template>
    <div class="container">
        <h2 class="text-info">Mantenimiento de Permisos</h2>
        <hr />
        <div v-if="form">
            <PermissionForm 
                v-bind:types="$store.state.types" 
                v-bind:permission="$store.state.permission"  
                v-on:onAdd="add($event)"
                v-on:onUpdate="update($event)"
                v-on:onCancel="cancel()"/>
        </div>

        <div v-else-if="!form">
            <button class="btn btn-primary mb-1" @click="form=true">Agregar</button>

            <PermissionList 
                v-bind:permissions="$store.state.permissions" 
                v-on:onRemove="remove($event)" 
                v-on:onEdit="edit($event)"/>
        </div>
    </div>
</template>
<script>
import PermissionList from './PermissionList';
import PermissionForm from './PermissionForm';

const url = "https://localhost:5001/Permissions/";
const urlType = "https://localhost:5001/PermissionType/";

export default {
    components: { PermissionList, PermissionForm },
    data(){
        return{
            form: false
        }
    },
    methods:{
        load(){
            setTimeout(()=>{
                fetch(url)
                .then(response => response.json())
                .then(data => this.$store.commit('setPermissions', data));
            },100);
        },
        remove(item){
            this.$confirm("Estas seguro de eliminar el permiso?")
            .then(() => {
                fetch(url + item.id,{
                    method: 'DELETE',
                    headers:{'Content-Type': 'application/json'}
                })
                .then(() => setTimeout(()=>this.load(),200))
                .catch(error => console.error('Error:', error));
            })
            .catch(()=>{});
        },
        edit(item){
            this.form = true;
            this.$store.commit('setPermission', JSON.parse(JSON.stringify(item)));
        },
        add(item){
            this.form = false;

            fetch(url,{
                method: 'POST',
                body: JSON.stringify(item),
                headers:{'Content-Type': 'application/json'}
            })
            .then(() => this.load())
            .catch(error => console.error('Error:', error));
        },
        update(item){
            this.form = false;

            fetch(url + item.id,{
                method: 'PUT',
                body: JSON.stringify(item),
                headers:{'Content-Type': 'application/json'}
            })
            .then(() => this.load())
            .catch(error => console.error('Error:', error));
        },
        cancel(){
            this.form = false;
            this.$store.commit('setPermission', {});
        }
    },
    created(){
        fetch(urlType)
        .then(response => response.json())
        .then(data => this.$store.commit('setTypes', data));

        this.load();
    }
}
</script>
<style scoped>

</style>