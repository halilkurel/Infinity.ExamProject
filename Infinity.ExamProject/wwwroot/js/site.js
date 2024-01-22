
var optionCount = @Model.OptionsDto.Count;

document.getElementById("addOption").addEventListener("click", function () {
    var newOptionHtml = `
                <label for="OptionsDto_${optionCount}__OptionName">Option Name</label>
                <input type="text" id="OptionsDto_${optionCount}__OptionName" name="OptionsDto[${optionCount}].OptionName" />

                <label for="OptionsDto_${optionCount}__CorrectOption">Correct Option</label>
                <input type="checkbox" id="OptionsDto_${optionCount}__CorrectOption" name="OptionsDto[${optionCount}].CorrectOption" value="true" />
            `;

    var newOptionContainer = document.createElement("div");
    newOptionContainer.innerHTML = newOptionHtml;

    document.querySelector("form").insertBefore(newOptionContainer, document.getElementById("addOption"));

    optionCount++;
});
