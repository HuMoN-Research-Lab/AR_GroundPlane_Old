function [trials_in_random_order_table] = create_random_ordered_block_table(block_struct,n_reps)
%create_random_ordered_block_table takes in a block of terrain configurations and
%then creates an ordered table list of the terrains, repeated
%`n_reps` times. special purpose function for ARGP experiment, but could be
%scaled for different number of repetitions

num_trials = size(block_struct,1)*n_reps; % the number of trials in a given block

rc = [num_trials 2]; % rows and columns for the table
varTypes = ["double","string"];
varNames = ["Rand_Trial_Num","File_Name"];
temp_table = table('Size',rc,'VariableTypes',varTypes,'VariableNames',varNames);

row_counter = 1;

random_order = randperm(num_trials);

for iN = 1:size(block_struct,1)
    
    for iR = 1:n_reps % repeat through this n_reps times

    temp_table.Rand_Trial_Num(row_counter) = random_order(row_counter);
    temp_table.File_Name(row_counter) = block_struct(iN).name;

    row_counter = row_counter + 1;

    end

end

trials_in_random_order_table = sortrows(temp_table); % sort the rows so that the trials are now in a random order

end