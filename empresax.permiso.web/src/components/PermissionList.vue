<template>
    <div>
        <div class="table-responsive">
            <table class="table table-sm table-striped table-bordered">
                <thead class="thead-dark text-center">
                    <tr>
                        <th>Nombres</th>
                        <th>Apellidos</th>
                        <th>Tipo</th>
                        <th>Registro</th>
                        <th>Accion</th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="(permission,i) in permissions" v-bind:key="i">
                        <td>{{permission.name}}</td>
                        <td>{{permission.lastName}}</td>
                        <td>{{permission.type.description}}</td>
                        <td>{{permission.date | moment("d/MM/YYYY hh:mm:ss")}}</td>
                        <td class="text-center">
                            <button class="btn btn-sm btn-info" v-on:click="edit(permission)">Editar</button>
                            <button class="btn btn-sm btn-danger ml-1" v-on:click="remove(permission)">Eliminar</button>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
</template>
<script>
export default {
  props:{
      permissions: Array
  },
  methods:{
      edit(item){
          this.$emit('onEdit',item);
      },
      remove(item){
          this.$emit('onRemove',item);
      }
  }
}
</script>

<style scoped>

</style>
