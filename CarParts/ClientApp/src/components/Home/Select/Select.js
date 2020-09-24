import React from 'react';



const SelectItem = ({id, selectName = "Select", options=[], onSelect }) => {

    const years = options.map(item => (
        <option key={item}>{item}</option>
    ))
    return (
        <div className="col-lg-3 col-md-3 col-sm-12 my-sm-2 pb-2 search-boxes">
            <select name="make" id="so_make0" className="select-part" onChange={onSelect}>
                <option>{selectName}</option>
                {years}
            </select>
        </div>
    )
}

export default SelectItem;