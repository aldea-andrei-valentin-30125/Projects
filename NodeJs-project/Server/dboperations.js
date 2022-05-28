const sql = require('mssql/msnodesqlv8')

const config = require('./dbconfig');

const phone = require('./phone')

async function getPhones(){
    try {
        let pool = await sql.connect(config);
        let phones = await pool.request().query("SELECT * from dbo.Products");
        return phones.recordsets;
    }
    catch (error) {
        console.log(error);
    }
}

async function getPhone(phoneId) {
    try {
        let pool = await sql.connect(config);
        let phone = await pool.request()
            .input('input_parameter', sql.Int, phoneId)
            .query("SELECT * from dbo.Products where Id = @input_parameter");
        return phone.recordset;

    }
    catch (error) {
        console.log(error);
    }
}

async function deletePhone(phoneId) {
    try {
        let pool = await sql.connect(config);
        let phone = await pool.request()
            .input('input_parameter', sql.Int, phoneId)
            .query("DELETE from dbo.Products where Id = @input_parameter");
        return phone.recordset;

    }
    catch (error) {
        console.log(error);
    }
}


async function addPhone(phone) {
    try {
        let pool = await sql.connect(config);
        await pool.request()
            .input('Id', sql.Int, phone.Id)
            .input('Name', sql.NVarChar, phone.Name)
            .input('Brand', sql.NVarChar, phone.Brand)
            .input('Price', sql.Decimal(10,2), phone.Price)
            .input('Discount', sql.Decimal(10,2), phone.Discount)
            .input('Color', sql.NVarChar, phone.Color)
            .input('Description', sql.NVarChar, phone.Description)
            .input('DisplayType', sql.NVarChar, phone.DisplayType)
            .input('RAMmemory', sql.NVarChar, phone.RAMmemory)
            .input('ReleaseDate', sql.DateTime, phone.ReleaseDate)
            .query("INSERT INTO dbo.Products (Name, Brand, Price, Discount, Color, Description, DisplayType, RAMmemory, ReleaseDate) VALUES (@Name, @Brand, @Price, @Discount, @Color, @Description, @DisplayType, @RAMmemory, @ReleaseDate)");
        
    }
    catch (error) {
        console.log(error);
    }

}

async function updatePhone(phone) {
    try {
        let pool = await sql.connect(config);
        await pool.request()
            .input('input_parameter', sql.Int, phone.Id)
            .input('name', sql.NVarChar, phone.Name)
            .input('price', sql.Decimal(10,2), phone.Price)
            .input('discount', sql.Decimal(10,2), phone.Discount)
            .input('description', sql.NVarChar, phone.Description)
            .query("UPDATE dbo.Products SET Name = @name, Price = @price, Discount = @discount, Description = @description where Id = @input_parameter");

    }
    catch (error) {
        console.log(error);
    }

}

module.exports = {
    getPhones: getPhones,
    getPhone : getPhone,
    deletePhone: deletePhone,
    addPhone : addPhone,
    updatePhone: updatePhone
}