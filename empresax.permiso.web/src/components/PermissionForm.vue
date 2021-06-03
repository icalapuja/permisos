<template>
    <div class="container-new">
        <div class="form-group row">
          <label class="col-sm-6 col-form-label text-sm-right">Nombre</label>
          <div class="col-sm-6">
            <input type="text" class="form-control form-control-sm" maxlength="50" v-model="permission.name">
          </div>
        </div>

        <div class="form-group row">
          <label  class="col-sm-6 col-form-label text-sm-right">Apellidos</label>
          <div class="col-sm-6">
            <input type="text" class="form-control form-control-sm" maxlength="50" v-model="permission.lastName">
          </div>
        </div>

        <div class="form-group row">
          <label  class="col-sm-6 col-form-label text-sm-right">Tipo</label>
          <div class="col-sm-6">
            <select class="form-control" v-model="permission.type">
              <option v-for="(type,i) in types" v-bind:key="i" :value="type">{{type.description}}</option>
            </select>
          </div>
        </div>

        <div class="form-group row">
          <div class="col-sm-6 offset-sm-6">
            <button class="btn btn-success" @click="save()">Grabar</button>
            <button class="btn btn-danger ml-1" @click="cancel()">Cancelar</button>
          </div>
        </div>
    </div>
</template>
<script>
export default {
  props:{
    permission: {},
    types: Array
  },
  methods:{
    validate(permission){
      if(!permission.name){
        return false;
      }

      if(!permission.lastName){
        return false;
      }

      if(!permission.type){
        return false;
      }

      return true;
    },
    save(){
      if(this.validate(this.permission)){
        if(this.permission.id){
          this.$emit('onUpdate',this.permission);
        }else{
          this.$emit('onAdd',this.permission);
        }
      }else{
        this.$alert("Debe completar todos los datos");
      }
    },
    cancel(){
      this.$emit('onCancel');
    }
  }
}
</script>
<style scoped>
  .container-new{
    max-width: 600px;
    margin: auto;
  }
</style>